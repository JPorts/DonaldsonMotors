// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="SingleButtonPartial.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    /// Class describing the properties for an individual button in a view.
    /// </summary>
    public class SingleButtonPartial
    {
        /// <summary>
        /// Gets or sets the type of the button.
        /// </summary>
        /// <value>The type of the button.</value>
        public string ButtonType { get; set; }
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>The glyph.</value>
        public string Glyph { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>The booking identifier.</value>
        public int? BookingId { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public int? CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the car part identifier.
        /// </summary>
        /// <value>The car part identifier.</value>
        public int? CarPartId { get; set; }
        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public int? JobId { get; set; }
        /// <summary>
        /// Gets or sets the basket identifier.
        /// </summary>
        /// <value>The basket identifier.</value>
        public int? BasketId { get; set; }
        /// <summary>
        /// Gets or sets the review identifier.
        /// </summary>
        /// <value>The review identifier.</value>
        public int? ReviewId { get; set; }
        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>The supplier identifier.</value>
        public int? SupplierId { get; set; }
        /// <summary>
        /// Gets or sets the staff identifier.
        /// </summary>
        /// <value>The staff identifier.</value>
        public string StaffId { get; set; }
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        public string RoleId { get; set; }

        /// <summary>
        /// Gets the action parameter.
        /// </summary>
        /// <value>The action parameter.</value>
        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");

                if (BookingId != null && BookingId > 0)
                {
                    param.Append(String.Format("{0}", BookingId));
                }
                if (CustomerId != null && CustomerId> 0)
                {
                    param.Append(String.Format("{0}", CustomerId));
                }
                if (CarPartId != null && CarPartId > 0)
                {
                    param.Append(String.Format("{0}", CarPartId));
                }
                if (JobId != null && JobId > 0)
                {
                    param.Append(String.Format("{0}", JobId));
                }
                if (BasketId != null && BasketId > 0)
                {
                    param.Append(String.Format("{0}", BasketId));
                }
                if (ReviewId != null && ReviewId > 0)
                {
                    param.Append(String.Format("{0}", ReviewId));
                }
                if (StaffId != null && StaffId != "")
                {
                    param.Append(String.Format("{0}", StaffId));
                }
                if (RoleId != null && RoleId != "")
                {
                    param.Append(String.Format("{0}", RoleId));
                }
                if (SupplierId != null && SupplierId > 0)
                {
                    param.Append(String.Format("{0}", SupplierId));
                }


                return param.ToString();

            }
        }


    }
}