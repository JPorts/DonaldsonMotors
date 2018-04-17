using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class CarPart
    {
        [Key]
        public int PartId { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [Required]
        public string Description { get; set; }

        public string Colour { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public int ReorderQuantity { get; set; }


    }
}