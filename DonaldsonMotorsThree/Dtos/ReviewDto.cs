﻿// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="ReviewDto.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Dtos
{
    /// <summary>
    /// Class ReviewDto.
    /// </summary>
    public class ReviewDto
        {

        /// <summary>
        /// Gets or sets the review identifier.
        /// </summary>
        /// <value>The review identifier.</value>
        public int ReviewId { get; set; }
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public virtual string Id { get; set; }
    
        }

}