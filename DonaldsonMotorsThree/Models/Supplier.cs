using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Town { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}