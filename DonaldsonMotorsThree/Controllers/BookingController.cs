using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using DonaldsonMotorsThree.ViewModels;
using Microsoft.AspNet.Identity;

namespace DonaldsonMotorsThree.Controllers
{
    [System.Web.Mvc.AllowAnonymous]
    public class BookingController : Controller
    {

        private ApplicationDbContext _context;
        private VehicleRepository vehicleRepo;

        public BookingController()
        {
            _context = new ApplicationDbContext();
            vehicleRepo = new VehicleRepository();
        }


        // GET: Booking
        public ActionResult Index()
        {
            

            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateVehicleDetailsForm(List<Job> jobs, DateTime startDate, List<CarPart> carParts)
        {
            Booking currentBooking = new Booking
            {
                startDate = startDate,

            };

            var BookingVm = new BookingFormViewModel
            {
                Jobs = jobs,
                startDate = startDate
            };
            return View("CreateBookingTwo", BookingVm);
        }

        //POST: Booking/AddVehicle
        public ActionResult AddVehicle(VehicleDetails vehicle)
        {
            // Nested within try catch to pull entity validation properties into message// 
            try
            {
                // Pull current user id// 
                var userId = User.Identity.GetUserId();
                //pull associated customer// 
                var customer = _context.Customers.SingleOrDefault(c => c.Id == userId);
                //pull current customer id//
                var customerId = customer.CustomerId;
                // Assign to vehicle customer Id// 
                vehicle.CustomerId = customerId;
                // Ensure new vehicle entry//
                if (vehicle.VehicleId == 0)
                    // Repo handles the database functions//
                    vehicleRepo.Add(vehicle);
                    vehicleRepo.SaveChanges();
                // Return customer to confirm booking view// 
                var BookingVm = new BookingFormViewModel
                {
                    Vehicle = vehicle,

                };
                return View("ConfirmBooking", BookingVm);

              
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

        public ActionResult ConfirmBooking(Booking Booking, VehicleDetails vehicle)
        {
            // Pull current user id// 
            var userId = User.Identity.GetUserId();
            //pull associated customer// 
            var customer = _context.Customers.SingleOrDefault(c => c.Id == userId);
            //pull current customer id//
            var customerId = customer.CustomerId;
            // pull associated vehicle// 
            VehicleDetails Vehicle = _context.VehicleDetails.SingleOrDefault(v => v.CustomerId == customerId);
            // pull Job 
            var JobIds = Booking.JobIds.ToList();
            return View("Invoice");
        }

        // POST: Booking/Create
        [System.Web.Http.HttpPost]
        public ActionResult CreateBooking(int id)
        {
            //// If Model is not valid, throw bad request //
            if(!ModelState.IsValid)
              throw new HttpResponseException(HttpStatusCode.BadRequest);

            //  Grab customer from DB // 
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            //// If Customer is null, redirect as not found //
            if (customer == null)
                RedirectToAction("Register", "Account");
                

            var jobs = _context.Jobs.ToList();
            var viewModel = new BookingFormViewModel
            {
                Jobs = jobs
            };

            return View(viewModel);
        }

        public ActionResult ViewAll()
        {

            return View();
        }

        public ActionResult ActiveBookings()
        {
            return View();
        }

        public ActionResult GetBookingHistory()
        {
            return View();
        }


    }
}