﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Dtos
{
    public class CarPartDto
    {
        [Key]
        public int PartId { get; set; }

        public int SupplierId { get; set; }

        public string Name { get; set; }

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