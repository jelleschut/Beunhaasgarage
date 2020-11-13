using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Enums
{
    public enum StatusEnum
    {
        [Display(Name = "Registered")]
        REGISTERED,
        [Display(Name = "Work in Progress")]
        IN_PROGRESS,
        [Display(Name = "Ready")]
        READY,
        [Display(Name = "Signed Off")]
        SIGNED_OFF,
        [Display(Name = "Sample Test")]
        SAMPLE_TEST
    }
}
