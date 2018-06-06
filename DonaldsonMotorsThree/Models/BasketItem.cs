// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="BasketItem.cs" company="">
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
    /// This class is used to describe the individual items within a users basket
    /// </summary>

    public class BasketItem
    {
        // Declare Basket Item Properties// 
        /// <summary>
        /// Gets or sets the basket item identifier.
        /// </summary>
        /// <value>The basket item identifier.</value>
        public int BasketItemId { get; set; }
        /// <summary>
        /// Gets or sets the basket identifier.
        /// </summary>
        /// <value>The basket identifier.</value>
        public int BasketId { get; set; }
        /// <summary>
        /// Gets or sets the car part identifier.
        /// </summary>
        /// <value>The car part identifier.</value>
        public int CarPartId { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int quantity { get; set; }

    }
}