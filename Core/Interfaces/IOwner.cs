using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
    }
}
