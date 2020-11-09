using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        void EditCustomer(int id, Customer customer);
        void DeleteCustomer(int id);
    }
}
