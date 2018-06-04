using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using DonaldsonMotorsThree.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

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

                        bookingRepo.Add(vm.BookedBooking);
                        bookingRepo.SaveChanges();
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
    }
}