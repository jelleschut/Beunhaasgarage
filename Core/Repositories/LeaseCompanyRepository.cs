using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories
{
    public class LeaseCompanyRepository : ILeaseCompanyRepository
    {
        private List<LeaseCompany> _leaseCompanyStaticDB;
        public LeaseCompanyRepository()
        {
            _leaseCompanyStaticDB = new List<LeaseCompany>
            {
                new LeaseCompany() { Id = 1, Name = "SomeCompany", City = "SomeCity", Street = "SomeStreet", HouseNumber = 1, Zipcode = "1234AB"},
                new LeaseCompany() { Id = 2, Name = "OtherCompany", City = "OtherCity", Street = "OtherStreet", HouseNumber = 1, Zipcode = "4321XZ"},
                new LeaseCompany() { Id = 3, Name = "ThirdCompany", City = "ThirdCity", Street = "ThirdStreet", HouseNumber = 1, Zipcode = "0987TX"}
             };
        }

        public void AddLeaseCompany(LeaseCompany leaseCompany)
        {
            leaseCompany.Id = _leaseCompanyStaticDB.Max(lc => lc.Id) + 1;
            _leaseCompanyStaticDB.Add(leaseCompany);
        }

        public void DeleteLeaseCompany(int id)
        {
            var item = _leaseCompanyStaticDB.FirstOrDefault(lc => lc.Id == id);
            _leaseCompanyStaticDB.Remove(item);
        }

        public void EditLeaseCompany(int id, LeaseCompany leaseCompany)
        {
            var item = _leaseCompanyStaticDB.FirstOrDefault(lc => lc.Id == id);
            item.Name = leaseCompany.Name;
            item.City = leaseCompany.City;
            item.HouseNumber = leaseCompany.HouseNumber;
            item.Zipcode = leaseCompany.Zipcode;
        }

        public List<LeaseCompany> GetAllLeasecompanies()
        {
            return _leaseCompanyStaticDB;
        }

        public LeaseCompany GetLeaseCompany(int id)
        {
            return _leaseCompanyStaticDB.FirstOrDefault(lc => lc.Id == id);
        }
    }
}
