using System;
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
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        [DataType(DataType.Text)]
        [DisplayName("Licensenumber")]
        public string LicenseNumber { get; set; }
        [Required]
        public Brand Brand { get; set; }
        [Required]
        public Model Model { get; set; }
        [Required]
        public IOwner Owner { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public StatusEnum Status { get; set; }

    }
}
