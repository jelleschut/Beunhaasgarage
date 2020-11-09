using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Model
    {
        public int ModelId { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public virtual Brand Brand { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}
