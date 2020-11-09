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
    public class BrandsApiEndpoint : ControllerBase
    {

        private readonly IBrandRepository _brandRepository;

        public BrandsApiEndpoint(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public List<Brand> Get()
        {
            return _brandRepository.GetAllBrands();
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return _brandRepository.GetBrand(id);
        }

        // POST api/<BrandsController>
        [HttpPost]
        public void Post(Brand brand)
        {
            _brandRepository.AddBrand(brand);
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, Brand brand)
        {
            if (BrandExists(id))
            {
                _brandRepository.EditBrand(id, brand);
            }
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool BrandExists(int id)
        {
            return _brandRepository.GetBrand(id) != null;
        }
    }
}
