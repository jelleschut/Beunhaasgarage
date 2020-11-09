using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    [DisplayName("Maintenance Specifiation")]
    public class MaintenanceSpecification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public int Milage { get; set; }
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        public MaintenanceTypeEnum Type { get; set; }
        [Required]
        public Car Car { get; set; }
    }
}
