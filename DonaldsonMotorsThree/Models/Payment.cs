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
        public int PaymentId { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string NameOnCard { get; set; }

        [Required]
        public string ExpiryDate { get; set; }

        [Required]
        public int SecurityCode { get; set; }




    }
}