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
    public class ModelsApiEndpoint : ControllerBase
    {
        private readonly IModelRepository _modelRepository;
        public ModelsApiEndpoint(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        // GET: api/<ModelsController>
        [HttpGet("Brand/{BrandId}")]
        public IEnumerable<Model> GetByBrand(int brandId)
        {
            return _modelRepository.GetModelsByBrand(brandId);
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public IEnumerable<Model> Get()
        {
            return _modelRepository.GetAllModels();
        }

        // POST api/<ModelsController>
        [HttpPost]
        public void Post([FromBody] Model model)
        {
            _modelRepository.EditModel(model.Id, model);

        }

        [HttpPut("{id}/{modelName}")]
        public void Put(int id, string modelName)
        {
            _modelRepository.EditModel(id, modelName);
        }


        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] Model model)
        {
            if (ModelExists(id))
            {
                _modelRepository.EditModel(id, model);
            }
        }

        // DELETE api/<ModelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (ModelExists(id))
            {
                _modelRepository.DeleteModel(id);
            }
        }

        private bool ModelExists(int id)
        {
            return _modelRepository.GetModel(id) != null;
        }
    }
}
