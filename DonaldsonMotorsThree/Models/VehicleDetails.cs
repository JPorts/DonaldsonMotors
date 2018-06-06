// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="VehicleDetails.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    /// Class VehicleDetails.
    /// </summary>
    public class VehicleDetails
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        /// <value>The vehicle identifier.</value>
        [Key]
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the reg number.
        /// </summary>
        /// <value>The reg number.</value>
        [DisplayName("Registration Number")]
        [Required]
        public string RegNumber { get; set; }

        /// <summary>
        /// Gets or sets the make.
        /// </summary>
        /// <value>The make.</value>
        [Required]
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the size of the engine.
        /// </summary>
        /// <value>The size of the engine.</value>
        [DisplayName("Engine Size")]
        [Required]
        public string EngineSize { get; set; }


        /// <summary>
        /// Gets or sets the milage.
        /// </summary>
        /// <value>The milage.</value>
        [Required]
        public int Milage { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>The booking identifier.</value>
        public int BookingId { get; set; }






    }
}