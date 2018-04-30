using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Customer : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer Id")]
        public new int CustomerId { get; set; }

        [Display(Name="Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        public List<Booking> Bookings { get; set; }

       



    }
}