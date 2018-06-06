// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="PaymentController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonaldsonMotorsThree.Controllers
{
    /// <summary>
    /// Class PaymentController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class PaymentController : Controller
    {
        // GET: Payment
        /// <summary>
        /// Pays the index.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult PayIndex()
        {
            return View();
        }
    }
}