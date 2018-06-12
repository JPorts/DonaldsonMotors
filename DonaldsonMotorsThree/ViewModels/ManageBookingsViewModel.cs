// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-12-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-08-2018
// ***********************************************************************
// <copyright file="ManageBookingsViewModel.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.ViewModels
{
    /// <summary>
    /// Class ManageBookingsViewModel.
    /// </summary>
    public class ManageBookingsViewModel
    {
        /// <summary>
        /// Gets or sets the booking.
        /// </summary>
        /// <value>The booking.</value>
        public Booking Booking { get; set; }
        /// <summary>
        /// Gets or sets the active bookings.
        /// </summary>
        /// <value>The active bookings.</value>
        public List<Booking> ActiveBookings { get; set; }

        /// <summary>
        /// Gets or sets the requested bookings.
        /// </summary>
        /// <value>The requested bookings.</value>
        public List<Booking> RequestedBookings { get; set; }

        /// <summary>
        /// Gets or sets the cancelled bookings.
        /// </summary>
        /// <value>The cancelled bookings.</value>
        public List<Booking> CancelledBookings { get; set; }

        /// <summary>
        /// Gets or sets the complete bookings.
        /// </summary>
        /// <value>The complete bookings.</value>
        public List<Booking> CompleteBookings { get; set; }

    }
}