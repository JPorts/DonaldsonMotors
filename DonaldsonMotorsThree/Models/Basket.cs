// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="Basket.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    /// This class is used to describe the properties of the basket
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Gets or sets the basket identifier.
        /// </summary>
        /// <value>The basket identifier.</value>
        public int BasketId { get; set; }
        /// <summary>
        /// Gets or sets the basket items.
        /// </summary>
        /// <value>The basket items.</value>
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Basket"/> class.
        /// </summary>
        public Basket()
        {
            //BasketItems = List<BasketItem>();
        }
    }
}