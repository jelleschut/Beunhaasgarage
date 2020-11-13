using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Enums
{
    public enum OwnerEnum
    {
        [Display(Name = "Lease Company")]
        LEASECOMPANY,
        [Display(Name = "Customer")]
        CUSTOMER
    }
}
