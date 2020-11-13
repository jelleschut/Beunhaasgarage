using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Web.ViewModels
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
        public IEnumerable<Owner> Drivers { get; set; }
    }
}
