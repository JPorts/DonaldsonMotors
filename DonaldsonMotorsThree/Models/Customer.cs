using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public int VehicleId { get; set; }

        public int PaymentId { get; set; }

        public List<Booking> Bookings { get; set; }

       



    }
}