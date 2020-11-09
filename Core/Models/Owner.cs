using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Core.Enums;

namespace Core.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [DisplayName("No.")]
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        public OwnerEnum OwnerType { get; set; }

        //Navigation Properties
        public virtual List<Car> CarOwners { get; set; }
        public virtual List<Car> CarDrivers { get; set; }
    }
}
