using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    ///  This class is used to describe the properties of the basket 
    /// </summary>
    public class Basket
    {
        public int BasketId { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        public Basket()
        {
            //BasketItems = List<BasketItem>();
        }
    }
}