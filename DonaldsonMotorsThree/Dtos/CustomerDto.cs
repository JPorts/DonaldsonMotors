// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="CustomerDto.cs" company="">
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
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Dtos
{
    /// <summary>
    /// Class CustomerDto.
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer Id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        /// <value>The vehicle identifier.</value>
        [Display(Name = "Vehicle Id")]
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>The payment identifier.</value>
        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the bookings.
        /// </summary>
        /// <value>The bookings.</value>
        public List<Booking> Bookings { get; set; }

    }
}