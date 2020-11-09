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

        private readonly IMaintenanceSpecificationRepository _msRepository;

        public MaintenanceSpecificationsApiEndpoint(IMaintenanceSpecificationRepository msRepository)
        {
            _msRepository = msRepository;
        }

        // GET: api/<MaintenanceSpecificationsApiEndpoint>
        [HttpGet]
        public IEnumerable<MaintenanceSpecification> Get()
        {
            return _msRepository.GetAllMaintenanceSpecifications();
        }

        // GET api/<MaintenanceSpecificationsApiEndpoint>/5
        [HttpGet("{id}")]
        public MaintenanceSpecification Get(int id)
        {
            return _msRepository.GetMaintenanceSpecification(id);
        }

        // POST api/<MaintenanceSpecificationsApiEndpoint>
        [HttpPost]
        public void Post([FromForm][Bind(Prefix = "MaintenanceSpecification")] MaintenanceSpecification ms)
        {
            _msRepository.AddMaintenanceSpecification(ms);
        }

        // PUT api/<MaintenanceSpecificationsApiEndpoint>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm][Bind(Prefix = "MaintenanceSpecification")] MaintenanceSpecification ms)
        {
            if (MSExists(id))
            {
                _msRepository.EditMaintenanceSpecification(id, ms);
            }

        }

        // DELETE api/<MaintenanceSpecificationsApiEndpoint>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (MSExists(id))
            {
                _msRepository.DeleteMaintenanceSpecification(id);
            }

        }

        private bool MSExists(int id)
        {
            return _msRepository.GetMaintenanceSpecification(id) != null;
        }
    }
}
