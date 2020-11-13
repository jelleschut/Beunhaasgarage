using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using DataAccessLayer;
using Core.Interfaces;
using Core.Enums;

namespace Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarsApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CarsApiEndpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _unitOfWork.Cars.GetAllAsync();
            if(cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        // GET: api/CarsApiEndpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _unitOfWork.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/CarsApiEndpoint/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, [FromBody] Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }

            _unitOfWork.Cars.UpdateAsync(car);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpPut("Maintenance/{id}")]
        public async Task<ActionResult<Car>> StartMaintenance(int id)
        {
            Car car = _unitOfWork.Cars.Find(id);
            
            car.Status = car.Status switch
            {
                StatusEnum.REGISTERED => StatusEnum.IN_PROGRESS,
                StatusEnum.IN_PROGRESS => StatusEnum.READY,
                StatusEnum.READY => SampleTestGenerator(),
                StatusEnum.SAMPLE_TEST => StatusEnum.SIGNED_OFF,
                _ => car.Status,
            };

            _unitOfWork.Cars.UpdateAsync(car);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return car;
        }

        // POST: api/CarsApiEndpoint
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _unitOfWork.Cars.Add(car);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetCar", new { id = car.CarId }, car);
        }

        // DELETE: api/CarsApiEndpoint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _unitOfWork.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _unitOfWork.Cars.Remove(car);
            await _unitOfWork.CompleteAsync();

            return car;
        }

        private StatusEnum SampleTestGenerator()
        {
            Random r = new Random();
            return r.Next(10) <= 3 ? StatusEnum.SAMPLE_TEST : StatusEnum.SIGNED_OFF;
        }

        private bool CarExists(int id)
        {
            return _unitOfWork.Cars.Find(id) != null;
        }
    }
}
