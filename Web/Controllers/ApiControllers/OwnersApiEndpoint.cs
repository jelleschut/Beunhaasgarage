using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnersApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<OwnerApiEndpoint>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _unitOfWork.Owners.GetAll();
            return Ok(result);
        }

        // GET api/<OwnerApiEndpoint>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (OwnerExists(id))
            {
                var result = _unitOfWork.Brands.GetById(id);
                return Ok(result);
            }
            return NotFound(id);
        }

        // POST api/<OwnerApiEndpoint>
        [HttpPost]
        public IActionResult Post(Owner owner)
        {
            _unitOfWork.Owners.Add(owner);
            _unitOfWork.Complete();
            return Ok(owner);
        }

        // POST api/<OwnerApiEndpoint>
        //[HttpPost]
        //public void Post([FromForm][Bind(Prefix="Customer")] Owner owner)
        //{
        //        _unitOfWork.Owners.Add(owner);
        //}

        // PUT api/<OwnerApiEndpoint>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Owner owner)
        {
            if (OwnerExists(id))
            {
                _unitOfWork.Owners.Update(owner);
                _unitOfWork.Complete();
                return Ok(owner);
            }
            return NotFound(id);
        }

        // PUT api/<OwnerApiEndpoint>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromForm][Bind(Prefix = "Customer")] Owner customer)
        //{
        //    if(OwnerExists(id))
        //    {
        //        _unitOfWork.Owners.Update(customer);
        //    }
        //}


        // DELETE api/<OwnerApiEndpoint>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (OwnerExists(id))
            {
                _unitOfWork.Owners.Remove(_unitOfWork.Owners.GetById(id));
                _unitOfWork.Complete();
                return NoContent();
            }
            return NotFound(id);
        }

        private bool OwnerExists(int id)
        {
            return _unitOfWork.Owners.GetById(id) != null;
        }
    }
}
