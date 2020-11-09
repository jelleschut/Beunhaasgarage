using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    [DisplayName("Maintenance Specification")]
    public class MaintenanceSpecification
    {
        public int MaintenanceSpecificationId { get; set; }
        public DateTime Date { get; set; }
        public int Milage { get; set; }
        public string Description { get; set; }
        public MaintenanceTypeEnum MaintenanceType { get; set; }

        //Navigation Properties
        public virtual Car Car { get; set; }
    }
}
