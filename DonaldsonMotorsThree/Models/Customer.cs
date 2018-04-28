using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Customer : User
    {
        [Key]
        [Display(Name="Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name="Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        public List<Booking> Bookings { get; set; }

       



    }
}