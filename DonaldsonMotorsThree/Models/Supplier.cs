// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="Supplier.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    /// Class Supplier.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>The supplier identifier.</value>
        [Key]
        [Display(Name = "Supplier Id")]
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        /// <value>The name of the supplier.</value>
        [Required]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        /// <value>The town.</value>
        public string Town { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        /// <value>The postcode.</value>
        [Required]
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>The telephone number.</value>
        [Required]
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>The name of the contact.</value>
        [Required]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}