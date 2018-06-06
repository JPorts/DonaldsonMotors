// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="JobTypes.cs" company="">
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
    /// Class JobTypes.
    /// </summary>
    public class JobTypes
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the job requirements.
        /// </summary>
        /// <value>The job requirements.</value>
        [Display(Name = "Job Requirements")]
        [Required]
        public string JobRequirements { get; set; }

        /// <summary>
        /// Gets or sets the job cost.
        /// </summary>
        /// <value>The job cost.</value>
        [Display(Name = "Price")]
        [Required]
        public double JobCost { get; set; }


        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>The parts.</value>
        [Display(Name = "Parts")]
        public List<CarPart> Parts{ get; set; }
    }
}