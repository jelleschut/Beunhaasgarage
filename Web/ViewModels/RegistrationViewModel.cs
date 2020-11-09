using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Web.ViewModels
{
    public class RegistrationViewModel
    {
        public Owner Owner { get; set; }
        public Car Car { get; set; }
        public MaintenanceSpecification Maintenance { get; set; }
    }
}
