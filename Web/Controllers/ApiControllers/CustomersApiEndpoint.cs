using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersApiEndpoint : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersApiEndpoint(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<CustomerApiEndpoint>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepository.GetAllCustomers();
        }

        // GET api/<CustomerApiEndpoint>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customerRepository.GetCustomer(id);
        }

        // POST api/<CustomerApiEndpoint>
        [HttpPost]
        public void Post([FromForm][Bind(Prefix="Customer")] Customer customer)
        {
                _customerRepository.AddCustomer(customer);
        }

        // PUT api/<CustomerApiEndpoint>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm][Bind(Prefix = "Customer")] Customer customer)
        {
            if(CustomerExists(id))
            {
                _customerRepository.EditCustomer(id, customer);
            }
        }

        // DELETE api/<CustomerApiEndpoint>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if(CustomerExists(id))
            {
                _customerRepository.DeleteCustomer(id);
            }
        }

        private bool CustomerExists(int id)
        {
            return _customerRepository.GetCustomer(id) != null;
        }
    }
}
