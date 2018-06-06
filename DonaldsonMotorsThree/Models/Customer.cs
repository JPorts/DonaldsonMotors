// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="Customer.cs" company="">
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
    /// Class Customer.
    /// </summary>
    /// <seealso cref="DonaldsonMotorsThree.Models.User" />
    public class Customer : User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Display(Name = "Customer Id")]
        //public new int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        /// <value>The vehicle identifier.</value>
        [Display(Name="Vehicle Id")]
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>The payment identifier.</value>
        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>The payment method.</value>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the bookings.
        /// </summary>
        /// <value>The bookings.</value>
        public List<Booking> Bookings { get; set; }
    }
}