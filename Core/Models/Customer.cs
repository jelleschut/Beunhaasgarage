using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Core.Models
{
    public class Customer : IOwner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name {
            get { return FirstName + " " + (!string.IsNullOrEmpty(Infix) ? Infix + " " : "") + LastName; }
            set { }
        }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [MaxLength(5)]
        public string Infix { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
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
        [DataType(DataType.PostalCode)]
        [MaxLength(10)]
        public string Zipcode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(30)]
        public string Email { get; set; }
    }
}
