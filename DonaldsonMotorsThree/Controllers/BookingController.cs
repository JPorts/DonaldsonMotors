

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
using Postal;

namespace DonaldsonMotorsThree.Controllers
{
    [System.Web.Mvc.Authorize]
    public class BookingController : Controller
    {

        private ApplicationDbContext _context;
        private VehicleRepository vehicleRepo;
        private BookingRepository bookingRepo;

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

        public double SumTotal(BookingFormViewModel bookingVm)
        {
            // Initialise total to 0.
            var total = 0.00;
            // loop through jobids in viewmodel
            foreach (var jobId in bookingVm.BookedBooking.JobIds)
            {
                // try to assign job object to id 
                try
                {
                    var job = _context.JobTypes.SingleOrDefault(j => j.Id == jobId);
                    // add jobcost from job object to total variable//
                    total += job.JobCost;
                }
                // catch any null references
                catch (NullReferenceException e)
                {
                    // return 0 is something goes wrong//
                    return 0;
                }
            }
            // if we get this far, all is working properly and total is returned. 
            return total;
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingFormViewModel vm, FormCollection formCollection)
        {
            // Try to create booking
            try
            {
                if (ModelState.IsValid)
                {
                    //var strJobs = formCollection.GetValue("Booking.JobIds").AttemptedValue;
                    // If model state is valid, add booking and save changes.
                    bookingRepo.Add(vm.BookedBooking);
                    bookingRepo.SaveChanges();
                }
                return View("Home");
            }
            // Else catch any validation exceptions and write to debug console// 
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
            return View("Home");
        }

        public ActionResult CreateBooking(BookingFormViewModel bookingVm, FormCollection formCollection)
        {
            // grab string job ids from form collection //
            var strJobs = formCollection.GetValue("BookedBooking.JobIds").AttemptedValue;

            // if jobs is not null or whitespace, split the job ids by the comman and parse to integers. add to list
            if (!strJobs.IsNullOrWhiteSpace()) bookingVm.BookedBooking.JobIds.AddRange(strJobs.Split(',').Select(Int32.Parse).ToList());

            // Nested within try catch to pull entity validation properties into message// 
            try
            {
                var userId = User.Identity.GetUserId();
                var customer = _context.Customers.SingleOrDefault(c => c.Id == userId);

                //pull current customer id//
                if (userId == null) RedirectToAction("Register", "Account");

                var customerId = customer.Id;
                var startDate = bookingVm.BookedBooking.StartDate; 

                AddJobsToBooking(bookingVm, strJobs, customerId, startDate);

                bookingVm.BookedBooking.CustomerId = customerId;

                // Assign to vehicle customer Id 
                bookingVm.Vehicle.CustomerId = customerId;
                // Assign vehicle to varc
                var vehicle = bookingVm.Vehicle;
                // Ensure new vehicle entry
                if (bookingVm.Vehicle.VehicleId == 0)
                    // Repo handles the database functions
                    vehicleRepo.Add(vehicle);
                vehicleRepo.SaveChanges();
                // Return customer to confirm booking view// 
                //Assign booking properties to VM//
                bookingVm.BookedCustomer = customer;
                bookingVm.Vehicle = vehicle;
                bookingVm.BookedBooking.BookingStatus = Constants.BookingStatus.Requested;
                var bookingTotal = SumTotal(bookingVm);
                bookingVm.BookedBooking.Total = bookingTotal;
                
                return View("ConfirmBooking", bookingVm);


            }
            // if something goes wrong, catch validation exceptions 
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    // foreach validation error, write to console//
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

        private void AddJobsToBooking(BookingFormViewModel bookingVm, string strJobs, string customerId, DateTime startDate)
        {
            var jobIds = strJobs.Split(',').Select(Int32.Parse).ToList();

            // Instantiate new JobsList 
            if (null == bookingVm.BookedBooking.Jobs)
                bookingVm.BookedBooking.Jobs = new List<Job>();

            var selectedJobs = _context.JobTypes
                                       .Where(t => jobIds.Contains(t.Id))
                                       .Select(r => new { r.Id, r.JobRequirements, r.JobCost });

            foreach (var selectedJob in selectedJobs)
            {
                var bookedJob = new Job
                {
                    StartDate = startDate,
                    JobRequirements = selectedJob.JobRequirements,
                    JobCost = selectedJob.JobCost,
                    JobTypeId = selectedJob.Id,
                    CustomerId = customerId,
                    JobStatus = Constants.JobStatus.Requested
                };
                bookingVm.BookedBooking.Jobs.Add(bookedJob);
            }
        }

        //POST: Booking/AddVehicle
        public ActionResult AddVehicle(VehicleDetails vehicle, BookingFormViewModel bookingVm)
        {
            // Nested within try catch to pull entity validation properties into message// 
            try
            {

                // Pull current user id// 
                var userId = User.Identity.GetUserId();
                //pull associated customer// 
                var customer = _context.Customers.SingleOrDefault(c => c.Id == userId);
                //pull current customer id//
                if (userId == null)
                    RedirectToAction("Register", "Account");

                var customerId = customer.Id;
                // Assign to vehicle customer Id// 
                vehicle.CustomerId = customerId;
                // Ensure new vehicle entry//
                if (vehicle.VehicleId == 0)
                    // Repo handles the database functions//
                    vehicleRepo.Add(vehicle);
                vehicleRepo.SaveChanges();
                // Return customer to confirm booking view// 

                bookingVm.BookedCustomer = customer;
                bookingVm.Vehicle = vehicle;
                bookingVm.BookedBooking.BookingStatus = Constants.BookingStatus.Requested;

                return View("ConfirmBooking", bookingVm);


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

        public ActionResult ConfirmBooking(Booking booking, VehicleDetails vehicle)
        {
   
            
            return View("Home");
        }



        public ActionResult ViewAll()
        {
            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }

        public ActionResult ActiveBookings()
        {
            var ActiveBookings = _context.Bookings.Where(b => b.BookingStatus == Constants.BookingStatus.Active);
            return View(ActiveBookings);
        }

        public ActionResult GetBookingHistory()
        {
            // Pull current user id// 
            var userId = User.Identity.GetUserId();
            //pull associated customer// 

            var BookingHistory = _context.Bookings.Where(b =>
                b.BookingStatus == Constants.BookingStatus.Complete && b.CustomerId == userId).ToList();

            // return view with booking history
            return View(BookingHistory);
        }

        
        public ActionResult Details(int id)
        {
            // grab booking from id match
            var booking = _context.Bookings.SingleOrDefault(s => s.BookingId == id);
            // return not found if bookking is null
            if (booking == null)
                return HttpNotFound();

            // return view with booking if all goes well
            return View(booking);
        }

        
        public ActionResult Edit(int id)
        {
            // pull booking from id match
            var booking = _context.Bookings.SingleOrDefault(b => b.BookingId == id);
            // if booking is null, return not found
            if (booking == null)
                return HttpNotFound();

            // if all goes well, return booking for amendment
            return View(booking);
        }

    }
}