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
    [System.Web.Mvc.Authorize]
    public class ConfirmedBookingController : Controller
    {

        private ApplicationDbContext _context;
        private BookingRepository bookingRepo;

        public ConfirmedBookingController()
        {
            _context = new ApplicationDbContext();
            bookingRepo = new BookingRepository();
        }


        // GET: Confirmed Bookings
        public ActionResult Index()
        {
                var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
                ViewBag.StripePublishKey = stripePublishKey;
                return View();
        }

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

        public ActionResult Create()
        {
            return View();
        }

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