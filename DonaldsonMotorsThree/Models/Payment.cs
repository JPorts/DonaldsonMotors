using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Payment
    {
        [Key]
        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        [Display(Name = "Cusotmer Id")]
        public int CustomerId { get; set; }

        [Display(Name="Card Number")]
        [Required]
        public string CardNumber { get; set; }

        [Display(Name = "Name on Card")]
        [Required]
        public string NameOnCard { get; set; }

        [Display(Name = "Expiry Date")]
        [Required]
        public string ExpiryDate { get; set; }

        [Display(Name = "Security Code")]
        [Required]
        public int SecurityCode { get; set; }




    }
}