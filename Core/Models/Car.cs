﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Enums;
using Core.Interfaces;

namespace Core.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [DisplayName("Licensenumber")]
        public string LicenseNumber { get; set; }
        public StatusEnum Status { get; set; }

        //Navigation Properties
        public virtual Brand Brand { get; set; }
        public virtual Model Model { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Owner Customer { get; set; }
        public virtual List<MaintenanceSpecification> MaintenanceSpecifications { get; set; }
    }
}
