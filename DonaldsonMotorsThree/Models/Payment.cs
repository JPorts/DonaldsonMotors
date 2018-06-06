// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="Payment.cs" company="">
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
    /// Class Payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>The payment identifier.</value>
        [Key]
        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Display(Name = "Cusotmer Id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>The card number.</value>
        [Display(Name="Card Number")]
        [Required]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the name on card.
        /// </summary>
        /// <value>The name on card.</value>
        [Display(Name = "Name on Card")]
        [Required]
        public string NameOnCard { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        /// <value>The expiry date.</value>
        [Display(Name = "Expiry Date")]
        [Required]
        public string ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the security code.
        /// </summary>
        /// <value>The security code.</value>
        [Display(Name = "Security Code")]
        [Required]
        public int SecurityCode { get; set; }




    }
}