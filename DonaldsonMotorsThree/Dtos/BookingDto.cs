﻿// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="BookingDto.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Dtos
{
    /// <summary>
    /// Class BookingDto.
    /// </summary>
    public class BookingDto
    {
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
        [Display(Name = "Booking Paid")]
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
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the date completed.
        /// </summary>
        /// <value>The date completed.</value>
        public DateTime? DateCompleted { get; set; }


        // IDs Linking other entitities // 
        /// <summary>
        /// Gets or sets the job ids.
        /// </summary>
        /// <value>The job ids.</value>
        public List<int> JobIds { get; set; }

        /// <summary>
        /// Gets or sets the part ids.
        /// </summary>
        /// <value>The part ids.</value>
        public List<int> PartIds { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public int JobId { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
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
        public virtual CarPart Part { get; set; }

        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value>The job.</value>
        public virtual Job Job { get; set; }

        /// <summary>
        /// Gets or sets the booking status.
        /// </summary>
        /// <value>The booking status.</value>
        public String BookingStatus { get; set; }
  

    }
}