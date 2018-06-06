// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="ConfirmedBookingController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using DonaldsonMotorsThree.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Postal;
using Stripe; 

namespace DonaldsonMotorsThree.Controllers
{
    /// <summary>
    /// Class ConfirmedBookingController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [System.Web.Mvc.Authorize]
    public class ConfirmedBookingController : Controller
    {

        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;
        /// <summary>
        /// The booking repo
        /// </summary>
        private BookingRepository bookingRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmedBookingController"/> class.
        /// </summary>
        public ConfirmedBookingController()
        {
            _context = new ApplicationDbContext();
            bookingRepo = new BookingRepository();
        }


        // GET: Confirmed Bookings
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
                var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
                ViewBag.StripePublishKey = stripePublishKey;
                return View();
        }

        /// <summary>
        /// Charges the specified stripe email.
        /// </summary>
        /// <param name="stripeEmail">The stripe email.</param>
        /// <param name="stripeToken">The stripe token.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            // further application specific code goes here

            return View();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified vm.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <param name="formCollection">The form collection.</param>
        /// <returns>ActionResult.</returns>
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingFormViewModel vm, FormCollection formCollection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var strJobs = formCollection.GetValue("Booking.JobIds").AttemptedValue;
                    if (null != vm.BookedBooking)
                    {
                        // Same ID for both at the moment.
                        //vm.BookedBooking.CustomerId = vm.BookedCustomer.Id;
                        //vm.BookedBooking.UserId = vm.BookedCustomer.Id;
                        var customerId = vm.BookedBooking.CustomerId;
                        var customerEmail = _context.Customers.Where(c => c.Id == customerId).Select(c => c.Email).SingleOrDefault(); 
                        bookingRepo.Add(vm.BookedBooking);
                        bookingRepo.SaveChanges();
                        sendInvoiceConfirmation(vm, customerEmail);
                    }
                }
                return View("ThankYou",vm.BookedCustomer);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        /// <summary>
        /// Sends the invoice confirmation.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <param name="customerEmail">The customer email.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult sendInvoiceConfirmation(BookingFormViewModel booking, string customerEmail)
        {
            // Instantiate dynamic email.
            dynamic email = new Email("BookingInvoice");
            email.To = booking.BookedCustomer;
           // var userEmailAddress = booking.BookedCustomer.Email;

            email.Message = "Booking Invoice";
            email.UserEmailAddress = customerEmail;

            email.Name = booking.BookedCustomer.FirstName;
            email.Total = booking.BookedBooking.Total;
            email.Jobs = booking.BookedBooking.Jobs;
            email.StartDate = booking.BookedBooking.StartDate;
            email.BookingId = booking.BookedBooking.BookingId;
            email.Send();

            return View("ThankYou", booking.BookedCustomer);

        }

    }
}