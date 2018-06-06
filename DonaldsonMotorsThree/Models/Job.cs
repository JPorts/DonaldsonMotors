// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="Job.cs" company="">
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
    /// Class Job.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        [Key]
        [Display(Name = "Job Id")]
        public int JobId { get; set; }
        /// <summary>
        /// Gets or sets the job requirements.
        /// </summary>
        /// <value>The job requirements.</value>
        [Display(Name = "Job Requirements")]
        [Required]
        public string JobRequirements { get; set; }

        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>The parts.</value>
        public virtual List<CarPart> Parts { get; set; }

        /// <summary>
        /// Gets or sets the job cost.
        /// </summary>
        /// <value>The job cost.</value>
        [Display(Name = "Price")]
        [Required]
        public double JobCost { get; set; }

        /// <summary>
        /// Gets or sets the job status.
        /// </summary>
        /// <value>The job status.</value>
        [Display(Name = "Status")]
        [Required]
        public string JobStatus { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Display(Name = "Customer Id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the job type identifier.
        /// </summary>
        /// <value>The job type identifier.</value>
        public int? JobTypeId { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        /// <summary>
        /// Gets or sets the completed by.
        /// </summary>
        /// <value>The completed by.</value>
        [Display(Name = "Completed By:")]
        public string CompletedBy { get; set; }

        /// <summary>
        /// Gets or sets the date completed.
        /// </summary>
        /// <value>The date completed.</value>
        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime? DateCompleted { get; set; }
        
        
    }
}