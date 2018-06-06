// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="Staff.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    /// Class Staff.
    /// </summary>
    /// <seealso cref="DonaldsonMotorsThree.Models.User" />
    public class Staff : User
    {
        // Declare Staff Properties // 
        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        /// <value>The dob.</value>
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        /// <summary>
        /// Gets or sets the med contact details.
        /// </summary>
        /// <value>The med contact details.</value>
        [Display(Name = "Medical Contact Details")]
        public string MedContactDetails { get; set; }
        /// <summary>
        /// Gets or sets the emerg contact details.
        /// </summary>
        /// <value>The emerg contact details.</value>
        [Display(Name = "Emergency Contact Details")]
        public string EmergContactDetails { get; set; }
        /// <summary>
        /// Gets or sets the ni number.
        /// </summary>
        /// <value>The ni number.</value>
        [Display(Name ="National Insurance Number")]
        public string NiNumber { get; set; }
        /// <summary>
        /// Gets or sets the area of expertise.
        /// </summary>
        /// <value>The area of expertise.</value>
        [Display(Name = "Area of Expertise")]
        public string AreaOfExpertise { get; set; }
        /// <summary>
        /// Gets or sets the contracts.
        /// </summary>
        /// <value>The contracts.</value>
        [Display(Name="Contract Type")]
        public IEnumerable<Contract> Contracts { get; set; }
        /// <summary>
        /// Gets or sets the rolename.
        /// </summary>
        /// <value>The rolename.</value>
        [Display(Name = "Role")]
        public string Rolename { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}