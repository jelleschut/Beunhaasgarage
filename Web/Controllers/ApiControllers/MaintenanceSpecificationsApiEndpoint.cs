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
    public class MaintenanceSpecificationsApiEndpoint : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public MaintenanceSpecificationsApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<MaintenanceSpecificationsApiEndpoint>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _unitOfWork.MaintenanceSpecifications.GetAll();
            return Ok(result);
        }

        // GET api/<MaintenanceSpecificationsApiEndpoint>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (MaintenanceSpecificationExists(id))
            {
                var result = _unitOfWork.MaintenanceSpecifications.GetById(id);
                return Ok(result);
            }
            return NotFound(id);
        }

        // POST api/<MaintenanceSpecificationsApiEndpoint>
        [HttpPost]
        public IActionResult Post(MaintenanceSpecification ms)
        {
            _unitOfWork.MaintenanceSpecifications.Add(ms);
            _unitOfWork.Complete();
            return Ok(ms);
        }

        // PUT api/<MaintenanceSpecificationsApiEndpoint>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, MaintenanceSpecification ms)
        {
            if (MaintenanceSpecificationExists(id))
            {
                _unitOfWork.MaintenanceSpecifications.Update(ms);
                _unitOfWork.Complete();
                return Ok(ms);
            }
            return NotFound(id);
        }


        // DELETE api/<MaintenanceSpecificationsApiEndpoint>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (MaintenanceSpecificationExists(id))
            {
                _unitOfWork.MaintenanceSpecifications.Remove(_unitOfWork.MaintenanceSpecifications.GetById(id));
                _unitOfWork.Complete();
                return NoContent();
            }
            return NotFound(id);
        }

        private bool MaintenanceSpecificationExists(int id)
        {
            return _unitOfWork.MaintenanceSpecifications.GetById(id) != null;
        }
    }
}
