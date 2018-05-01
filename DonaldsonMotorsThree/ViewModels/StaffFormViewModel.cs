using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    public class StaffFormViewModel
    {
        public Staff Staff { get; set; }
        
        public User User { get; set; }

    }
}