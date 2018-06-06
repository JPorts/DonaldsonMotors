// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="StaffDto.cs" company="">
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
    /// Class StaffDto.
    /// </summary>
    public class StaffDto
    {
        // Declare Staff Properties // 

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public int EmployeeId { get; set; }


        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        /// <value>The dob.</value>
        public DateTime Dob { get; set; }


        /// <summary>
        /// Gets or sets the qualifications.
        /// </summary>
        /// <value>The qualifications.</value>
        public List<string> Qualifications { get; set; }


        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>The mobile number.</value>
        public string MobileNumber { get; set; }


        /// <summary>
        /// Gets or sets the med contact details.
        /// </summary>
        /// <value>The med contact details.</value>
        public string MedContactDetails { get; set; }


        /// <summary>
        /// Gets or sets the emerg contact details.
        /// </summary>
        /// <value>The emerg contact details.</value>
        public string EmergContactDetails { get; set; }


        /// <summary>
        /// Gets or sets the ni number.
        /// </summary>
        /// <value>The ni number.</value>
        public string NiNumber { get; set; }


        /// <summary>
        /// Gets or sets the area of expertise.
        /// </summary>
        /// <value>The area of expertise.</value>
        public string AreaOfExpertise { get; set; }


        /// <summary>
        /// Gets or sets the contracts.
        /// </summary>
        /// <value>The contracts.</value>
        public IEnumerable<Contract> Contracts { get; set; }


        /// <summary>
        /// Gets or sets the rolename.
        /// </summary>
        /// <value>The rolename.</value>
        public string Rolename { get; set; }
    }
}