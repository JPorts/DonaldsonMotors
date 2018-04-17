using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class CarPart
    {
        public int PartId { get; set; }

        public int SupplierId { get; set; }

        public string Description { get; set; }

        public string Colour { get; set; }

        public decimal Price { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }


    }
}