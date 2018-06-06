// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="JobDto.cs" company="">
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
    /// Class JobDto.
    /// </summary>
    public class JobDto
    {

        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        [Key]
        public int JobId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        /// <value>The vehicle identifier.</value>
        public int VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the part identifier.
        /// </summary>
        /// <value>The part identifier.</value>
        public int PartId { get; set; }

        /// <summary>
        /// Gets or sets the completed by.
        /// </summary>
        /// <value>The completed by.</value>
        public string CompletedBy { get; set; }

        /// <summary>
        /// Gets or sets the date completed.
        /// </summary>
        /// <value>The date completed.</value>
        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }

        /// <summary>
        /// Gets or sets the job requirements.
        /// </summary>
        /// <value>The job requirements.</value>
        [Required]
        public string JobRequirements { get; set; }

        /// <summary>
        /// Gets or sets the job cost.
        /// </summary>
        /// <value>The job cost.</value>
        [Required]
        public decimal JobCost { get; set; }

        /// <summary>
        /// Gets or sets the job status.
        /// </summary>
        /// <value>The job status.</value>
        [Required]
        public int JobStatus { get; set; }

        /// <summary>
        /// Gets or sets the car part.
        /// </summary>
        /// <value>The car part.</value>
        public virtual CarPart CarPart { get; set; }

        /// <summary>
        /// Gets or sets the car part identifier.
        /// </summary>
        /// <value>The car part identifier.</value>
        public int? CarPartId { get; set; }
    }
}