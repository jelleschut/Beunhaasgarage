using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class LeaseCompany : IOwner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [DisplayName("Company")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string Street { get; set; }
        [Required]
        [DisplayName("No.")]
        public int HouseNumber { get; set; }
        [Required]
        [MaxLength(6)]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }
    }
}
