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
    public class LeaseCompanysApiEndpoint : ControllerBase
    {
        private readonly ILeaseCompanyRepository _leaseCompanyRepository;
        public LeaseCompanysApiEndpoint(ILeaseCompanyRepository leaseCompanyRepository)
        {
            _leaseCompanyRepository = leaseCompanyRepository;
        }

        // GET: api/<LeaseCompanysController>
        [HttpGet]
        public IEnumerable<LeaseCompany> Get()
        {
            return _leaseCompanyRepository.GetAllLeasecompanies();
        }

        // GET api/<LeaseCompanysController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LeaseCompanysController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LeaseCompanysController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LeaseCompanysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
