using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ILeaseCompanyRepository
    {
        void AddLeaseCompany(LeaseCompany leaseCompany);
        List<LeaseCompany> GetAllLeasecompanies();
        LeaseCompany GetLeaseCompany(int id);
        void EditLeaseCompany(int id, LeaseCompany leaseCompany);
        void DeleteLeaseCompany(int id);
    }
}
