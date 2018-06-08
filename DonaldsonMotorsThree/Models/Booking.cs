// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="Booking.cs" company="">
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
    /// Class Booking.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        public Booking()
        {
            Vehicle = new VehicleDetails(); 
            Jobs = new List<Job>();
        }

        // Booking properties // 
        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>The booking identifier.</value>
        [Key]
        public int BookingId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [paid for].
        /// </summary>
        /// <value><c>true</c> if [paid for]; otherwise, <c>false</c>.</value>
        [Display(Name="Booking Paid")]
        public bool PaidFor { get; set; }
        /// <summary>
        /// Gets or sets the duration in days.
        /// </summary>
        /// <value>The duration in days.</value>
        [Display(Name = "Duration")]
        public int? DurationInDays { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double? Total { get; set; }
        // Dates concerned with booking // 
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the date completed.
        /// </summary>
        /// <value>The date completed.</value>
        [Display(Name = "Date Completed")]
        public DateTime? DateCompleted { get; set; }
        // IDs Linking other entitities // 
        /// <summary>
        /// Gets or sets the job ids.
        /// </summary>
        /// <value>The job ids.</value>
        public List<int> JobIds { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public string CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// Gets or sets the staff.
        /// </summary>
        /// <value>The staff.</value>
        public virtual Staff Staff { get; set; }
        /// <summary>
        /// Gets or sets the part.
        /// </summary>
        /// <value>The part.</value>
        public List<Job> Jobs { get; set; }
        /// <summary>
        /// Gets or sets the booking status.
        /// </summary>
        /// <value>The booking status.</value>

        public virtual VehicleDetails Vehicle { get; set; }
        /// <summary>
        /// Gets or sets the reg number.
        /// </summary>
        /// <value>The reg number.</value>
        public string BookingStatus { get; set; }
    }
}