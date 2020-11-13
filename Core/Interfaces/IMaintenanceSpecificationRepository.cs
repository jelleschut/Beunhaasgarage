using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.Interfaces
{
    public interface IMaintenanceSpecificationRepository : IGenericRepository<MaintenanceSpecification>, IAsyncGenericRepository<MaintenanceSpecification>
    {
    }
}
