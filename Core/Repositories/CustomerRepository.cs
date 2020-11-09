using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Models;

namespace Core.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customerStaticDB;
        public CustomerRepository()
        {
            _customerStaticDB = new List<Customer>
            {
                new Customer() { Id = 1, FirstName = "Jelle", LastName = "Schut", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new Customer() { Id = 2, FirstName = "Fred", LastName = "Flintstone", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new Customer() { Id = 3, FirstName = "Sjaak", LastName = "Swart", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new Customer() { Id = 4, FirstName = "Pietje", LastName = "Puk", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new Customer() { Id = 5, FirstName = "Michael", LastName = "Schumacher", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new Customer() { Id = 6, FirstName = "Johan", LastName = "Cruijff", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
            };
        }
        public void AddCustomer(Customer customer)
        {
            customer.Id = _customerStaticDB.Max(c => c.Id) + 1;
            _customerStaticDB.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            var item = _customerStaticDB.FirstOrDefault(c => c.Id == id);
            _customerStaticDB.Remove(item);
        }

        public void EditCustomer(int id, Customer customer)
        {
            var item = _customerStaticDB.FirstOrDefault(c => c.Id == id);
            item.Name = customer.Name;
            item.FirstName = customer.FirstName;
            item.Infix = customer.Infix;
            item.LastName = customer.LastName;
            item.City = customer.City;
            item.Street = customer.Street;
            item.HouseNumber = customer.HouseNumber;
            item.Zipcode = customer.Zipcode;
            item.PhoneNumber = customer.PhoneNumber;
            item.Email = customer.Email;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerStaticDB;
        }

        public Customer GetCustomer(int id)
        {
            return _customerStaticDB.FirstOrDefault(c => c.Id == id);
        }
    }
}
