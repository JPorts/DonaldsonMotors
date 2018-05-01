using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    public class BookingFormViewModel
    {
        [Display(Name = "Jobs")]
        public IEnumerable<Job> Jobs { get; set; }

        public Job Job { get; set; }

        public Customer Customer { get; set; }

        public Booking Booking { get; set; }

    }
}