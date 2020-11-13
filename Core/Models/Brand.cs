using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Core.Interfaces;

namespace Core.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public virtual List<Model> Models { get; set; }
    }
}
