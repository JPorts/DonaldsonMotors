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


        [Display(Name = "Supplier ID")]
        public int SupplierId { get; set; }
        
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Colour { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }

        [Display(Name = "Reorder Quantity")]
        [Required]
        public int ReorderQuantity { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        public int CurrentQuantity { get; set; }


    }
}