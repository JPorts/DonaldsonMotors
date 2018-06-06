// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="CarPart.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    /// Class CarPart.
    /// </summary>
    public class CarPart
    {
        /// <summary>
        /// Gets or sets the part identifier.
        /// </summary>
        /// <value>The part identifier.</value>
        [Key]
        public int PartId { get; set; }
        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>The supplier identifier.</value>
        [Display(Name = "Supplier ID")]
        public int SupplierId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the colour.
        /// </summary>
        /// <value>The colour.</value>
        public string Colour { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the reorder level.
        /// </summary>
        /// <value>The reorder level.</value>
        [Required]
        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }

        /// <summary>
        /// Gets or sets the reorder quantity.
        /// </summary>
        /// <value>The reorder quantity.</value>
        [Display(Name = "Reorder Quantity")]
        [Required]
        public int ReorderQuantity { get; set; }
        /// <summary>
        /// Gets or sets the current quantity.
        /// </summary>
        /// <value>The current quantity.</value>
        [Display(Name = "Quantity")]
        [Required]
        public int CurrentQuantity { get; set; }
    }
}