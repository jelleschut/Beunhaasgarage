using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Core.Models;

namespace DataAccessLayer.Repositories
{
    public class MaintenanceSpecificationRepository : GenericRepository<MaintenanceSpecification>, IMaintenanceSpecificationRepository
    {
        public MaintenanceSpecificationRepository(GarageContext context) : base(context)
        {

        }
    }
}
