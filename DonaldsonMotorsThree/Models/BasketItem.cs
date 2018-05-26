using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
   /// <summary>
   /// This class is used to describe the individual items within a users basket
   /// </summary>
    
    public class BasketItem
    {
        // Declare Basket Item Properties// 
        public int BasketItemId { get; set; }
        public int BasketId { get; set; }
        public int CarPartId { get; set; } 
        public int quantity { get; set; }

    }
}