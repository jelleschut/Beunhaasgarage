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
    public class Old_ModelsApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public Old_ModelsApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ModelsController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _unitOfWork.Models.GetAll();
            return Ok(result);
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (ModelExists(id))
            {
                var result = _unitOfWork.Models.Find(id);
                return Ok(result);
            }
            return NotFound(id);
        }

        // GET api/<ModelsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ModelsController>
        [HttpPost]
        public IActionResult Post(Brand brand)
        {
            _unitOfWork.Brands.Add(brand);
            _unitOfWork.Complete();
            return Ok(brand);
        }

        // POST api/<ModelsController>
        //[HttpPost]
        //public void Post([FromBody] Model model)
        //{
        //    _modelRepository.EditModel(model.Id, model);
        //}

        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Model model)
        {
            if (ModelExists(id))
            {
                _unitOfWork.Models.Update(model);
                _unitOfWork.Complete();
                return Ok(model);
            }
            return NotFound(id);
        }

        // PUT api/<ModelsController>/5/name
        //[HttpPut("{id}/{modelName}")]
        //public void Put(int id, string modelName)
        //{
        //    _modelRepository.EditModel(id, modelName);
        //}


        // PUT api/<ModelsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromForm] Model model)
        //{
        //    if (ModelExists(id))
        //    {
        //        _modelRepository.EditModel(id, model);
        //    }
        //}

        // DELETE api/<ModelsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelExists(id))
            {
                _unitOfWork.Models.Remove(_unitOfWork.Models.Find(id));
                _unitOfWork.Complete();
                return NoContent();
            }
            return NotFound(id);
        }

        private bool ModelExists(int id)
        {
            return _unitOfWork.Models.Find(id) != null;
        }
    }
}
