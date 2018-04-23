using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class JqueryDatePicker
    {
        [Required] [Display(Name = "Select Date")]
        public DateTime jobDate { get; set; }
    }
}