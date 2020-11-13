using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Enums
{
    public enum MaintenanceTypeEnum
    {
        [Display(Name = "MOT")]
        MOT,
        [Display(Name = "Repair")]
        REPAIR,
        [Display(Name = "Maintenance")]
        MAINTENANCE
    }
}
