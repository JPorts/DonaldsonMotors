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


        public Customer BookedCustomer { get; set; }
        public Booking BookedBooking { get; set; }
        public VehicleDetails Vehicle { get; set; }
    }
}