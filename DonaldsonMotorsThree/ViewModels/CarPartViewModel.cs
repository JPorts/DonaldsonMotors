using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    public class CarPartViewModel
    {
        [Display(Name = "Supplier")]
        public IEnumerable<Supplier> Suppliers { get; set; }
        public CarPart CarPart { get; set; }

        public CarPartDto CarPartDto { get; set; }
    }
}