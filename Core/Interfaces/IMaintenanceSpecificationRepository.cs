using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.Interfaces
{
    public interface IMaintenanceSpecificationRepository
    {
        void AddMaintenanceSpecification(MaintenanceSpecification ms);
        List<MaintenanceSpecification> GetAllMaintenanceSpecifications();
        MaintenanceSpecification GetMaintenanceSpecification(int id);
        void EditMaintenanceSpecification(int id, MaintenanceSpecification ms);
        void DeleteMaintenanceSpecification(int id);
    }
}
