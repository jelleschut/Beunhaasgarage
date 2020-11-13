using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Old_BrandsApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public Old_BrandsApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _unitOfWork.Brands.GetAll();
            return Ok(result);
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(BrandExists(id))
            {
                var result = _unitOfWork.Brands.Find(id);
                return Ok(result);
            }
            return NotFound(id);
        }

        // POST api/<BrandsController>
        [HttpPost]
        public IActionResult Post(Brand brand)
        {
            _unitOfWork.Brands.Add(brand);
            _unitOfWork.Complete();
            return Ok(brand);
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Brand brand)
        {
            if (BrandExists(id))
            {
                _unitOfWork.Brands.Update(brand);
                _unitOfWork.Complete();
                return Ok(brand);
            }
            return NotFound(id);
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(BrandExists(id))
            {
                _unitOfWork.Brands.Remove(_unitOfWork.Brands.Find(id));
                _unitOfWork.Complete();
                return NoContent();
            }
            return NotFound(id);
        }

        private bool BrandExists(int id)
        {
            return _unitOfWork.Brands.Find(id) != null;
        }
    }
}
