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
    public class CarsApiEndpoint : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsApiEndpoint(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public List<Car> Get()
        {
            return _carRepository.GetAllCars();
        }

        //GET api/<CarsApiEndpoint>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _carRepository.GetCar(id);
        }

        // POST api/<CarsApiEndpoint>
        [HttpPost]
        public void Post([FromForm] [Bind(Prefix ="Car")] Car car)
        {
            _carRepository.AddCar(car);
        }

        // PUT api/<CarsApiEndpoint>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm][Bind(Prefix = "Car")] Car car)
        {
            if(CarExists(id))
            {
                _carRepository.EditCar(id, car);
            }
        }

        // DELETE api/<CarsApiEndpoint>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (CarExists(id))
            {
                _carRepository.DeleteCar(id);
            }
        }

        private bool CarExists(int id)
        {
            return _carRepository.GetCar(id) != null;
        }
    }
}
