using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enums;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Old_CarsApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public Old_CarsApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _unitOfWork.Cars.GetAll();
            return Ok(result);
        }

        //GET api/<CarsApiEndpoint>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (CarExists(id))
            {
                var result = _unitOfWork.Cars.Find(id);
                return Ok(result);
            }
            return NotFound(id);
        }

        // POST api/<CarsApiEndpoint>
        [HttpPost]
        public IActionResult Post(Car car)
        {
            _unitOfWork.Cars.Add(car);
            _unitOfWork.Complete();
            return Ok(car);
        }

        // PUT api/<CarsApiEndpoint>/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromForm][Bind(Prefix = "Car")] Car car)
        //{
        //    if(CarExists(id))
        //    {
        //        _carRepository.EditCar(id, car);
        //    }
        //}

        public IActionResult Put(int id, Car car)
        {
            if (CarExists(id))
            {
                _unitOfWork.Cars.Update(car);
                _unitOfWork.Complete();
                return Ok(car);
            }
            return NotFound(id);
        }

        // DELETE api/<CarsApiEndpoint>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (CarExists(id))
            {
                _unitOfWork.Cars.Remove(_unitOfWork.Cars.Find(id));
                _unitOfWork.Complete();
                return NoContent();
            }
            return NotFound(id);
        }

        private bool CarExists(int id)
        {
            return _unitOfWork.Cars.Find(id) != null;
        }
    }
}
