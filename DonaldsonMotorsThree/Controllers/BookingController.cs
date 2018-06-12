// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="BookingController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// <summary>
    /// Class BookingController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [System.Web.Mvc.Authorize]
    public class BookingController : Controller
    {

        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;
        /// <summary>
        /// The vehicle repo
        /// </summary>
        private VehicleRepository vehicleRepo;
        /// <summary>
        /// The booking repo
        /// </summary>
        private BookingRepository bookingRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController"/> class.
        /// </summary>
        public BookingController()
        {
            _context = new ApplicationDbContext();
            vehicleRepo = new VehicleRepository();
        }


        // GET: Booking
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
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
        /// Sums the total.
        /// </summary>
        /// <param name="bookingVm">The booking vm.</param>
        /// <returns>System.Double.</returns>
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

        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="bookingVm">The booking vm.</param>
        /// <param name="formCollection">The form collection.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult CreateBooking(BookingFormViewModel bookingVm, FormCollection formCollection)
        {
            // grab string job ids from form collection //
            var strJobs = formCollection.GetValue("BookedBooking.JobIds").AttemptedValue;
            bookingVm.BookedBooking.JobIds = new List<int>(); 

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
                bookingVm.BookedBooking.Vehicle.CustomerId = customerId;
                // Assign vehicle to varc
                //var vehicle = bookingVm.Vehicle;
                ////vehicle.BookingId = bookingVm.BookedBooking.BookingId;
                //// Ensure new vehicle entry
                //if (bookingVm.Vehicle.VehicleId == 0)
                //    // Repo handles the database functions
                //    vehicleRepo.Add(vehicle);
                //vehicleRepo.SaveChanges();

                // Return customer to confirm booking view// 
                //Assign booking properties to VM//
                bookingVm.BookedCustomer = customer;
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

        /// <summary>
        /// Adds the jobs to booking.
        /// </summary>
        /// <param name="bookingVm">The booking vm.</param>
        /// <param name="strJobs">The string jobs.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="startDate">The start date.</param>
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
        /// <summary>
        /// Adds the vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle.</param>
        /// <param name="bookingVm">The booking vm.</param>
        /// <returns>ActionResult.</returns>
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
                bookingVm.BookedBooking.Vehicle = vehicle;
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

        /// <summary>
        /// Confirms the booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <param name="vehicle">The vehicle.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult ConfirmBooking(Booking booking, VehicleDetails vehicle)
        {
   
            
            return View("Home");
        }



        /// <summary>
        /// Views all.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewAll()
        {
            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }

        /// <summary>
        /// Actives the bookings.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ActiveBookings()
        {
            var ActiveBookings = _context.Bookings.Where(b => b.BookingStatus == Constants.BookingStatus.Active);
            return View(ActiveBookings);
        }

        /// <summary>
        /// Gets the booking history.
        /// </summary>
        /// <returns>ActionResult.</returns>
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




        /// <summary>
        /// Gets the booking history.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult GetCustomerBookings()
        {
            // Pull current user id// 
            var userId = User.Identity.GetUserId();
            //pull associated customer// 
            var BookingHistory = _context.Bookings.Where(b => b.CustomerId == userId).ToList();
            // return view with booking history
            return View(BookingHistory);
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
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

        public void UpdateVehicle(VehicleDetails vehicleToUpdate,VehicleDetails updatedVehicle)
        {
            try
            {



                   _context.Entry(vehicleToUpdate).CurrentValues.SetValues(updatedVehicle);
                   _context.SaveChanges();

                    //_context.VehicleDetails.AddOrUpdate(updatedVehicle);
                    //_context.SaveChanges();


                    // if all goes well, return booking for amendment
                


                // Nested within try catch to pull entity validation properties into message// 

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

        public void UpdateBookingSection(Booking bookingToUpdate, Booking updatedBooking)
        {
            try
            {
                bookingToUpdate.Vehicle.Model = updatedBooking.Vehicle.Model;
                bookingToUpdate.Vehicle.Make = updatedBooking.Vehicle.Make;
                bookingToUpdate.Vehicle.CustomerId = updatedBooking.Vehicle.CustomerId;
                bookingToUpdate.Vehicle.EngineSize = updatedBooking.Vehicle.EngineSize;
                bookingToUpdate.Vehicle.RegNumber = updatedBooking.Vehicle.RegNumber;
                bookingToUpdate.Vehicle.Milage = updatedBooking.Vehicle.Milage;
                bookingToUpdate.Vehicle.VehicleId = updatedBooking.Vehicle.VehicleId;

                _context.Entry(bookingToUpdate).CurrentValues.SetValues(updatedBooking);
                _context.SaveChanges();
                // Nested within try catch to pull entity validation properties into message// 

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



        [System.Web.Mvc.HttpPost]
        public ActionResult UpdateBooking(BookingFormViewModel vm, FormCollection form)
        {
             
            try
            {

                // if booking is null, return not found
                if (vm.BookedBooking == null)
                    return HttpNotFound();

               // if (ModelState.IsValid)
               // {


                    var bookingToUpdate = _context.Bookings.Find(vm.BookedBooking.BookingId);
                    var updatedBooking = vm.BookedBooking;
                    var vehicleToUpdate = _context.VehicleDetails.Find(vm.BookedBooking.Vehicle.VehicleId);
                    var UpdatedVehicle = vm.BookedBooking.Vehicle;
                    // if booking is null, return not found
                    if (bookingToUpdate == null)
                        return HttpNotFound();


                UpdateBookingSection(bookingToUpdate, updatedBooking);
                UpdateVehicle(vehicleToUpdate, UpdatedVehicle);
                    
                    
                    //_context.Entry(vehicleToUpdate).CurrentValues.SetValues(UpdatedVehicle);
                   // _context.SaveChanges();


                    // if all goes well, return booking for amendment
               // }
                return RedirectToAction("GetCustomerBookings",vm);

                // Nested within try catch to pull entity validation properties into message// 

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
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int id)
        {
            BookingFormViewModel vm = new BookingFormViewModel();

            // pull booking from id match
            vm.BookedBooking = _context.Bookings.Include("Vehicle").Include("Jobs").SingleOrDefault(b => b.BookingId == id);
            var cust = _context.Customers.Where(c => c.Id == vm.BookedBooking.CustomerId).SingleOrDefault();
            vm.BookedCustomer = cust;

            // if booking is null, return not found
            if (vm.BookedBooking == null)
                return HttpNotFound();
            
            // if all goes well, return booking for amendment
            return View(vm);
        }


        public ActionResult Delete(int id, BookingFormViewModel bookingVm)
        {

           
            bookingVm.BookedBooking = _context.Bookings.Include("Vehicle").Include("Jobs").SingleOrDefault(b => b.BookingId == id);
            var cust = _context.Customers.Where(c => c.Id == bookingVm.BookedBooking.CustomerId).SingleOrDefault();
            bookingVm.BookedCustomer = cust;

            return View(bookingVm);
        }


        public ActionResult DeleteBooking(int id)
        {
            try {

                var thisBooking = _context.Bookings.Include("Vehicle").Include("Jobs").SingleOrDefault(b => b.BookingId == id);
                _context.Bookings.Remove(thisBooking);

                _context.SaveChanges();

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
            return View("Index");
        }





        public ActionResult ManageBookings()
        {
            // Create 4 tables for staff based on booking status - requested, active, canceled, complete
            var bookings = _context.Bookings.ToList();

            var activeBookings = new List<Booking>();
            var requestedBookings = new List<Booking>();
            var cancelledBookings = new List<Booking>();
            var completeBookings = new List<Booking>();


            // Loop through all bookings in database and assign to lists based on status
            foreach (var booking in bookings)
            {
                if (booking.BookingStatus == Constants.BookingStatus.Requested)
                {
                    requestedBookings.Add(booking);
                }
                else if (booking.BookingStatus == Constants.BookingStatus.Active)
                {
                    activeBookings.Add(booking);
                }
                else if (booking.BookingStatus == Constants.BookingStatus.Cancelled)
                {
                    cancelledBookings.Add(booking);
                }
                else if (booking.BookingStatus == Constants.BookingStatus.Complete)
                {
                    completeBookings.Add(booking);
                }
            }

            var vm = new ManageBookingsViewModel
            {
                RequestedBookings = requestedBookings,
                ActiveBookings = activeBookings,
                CompleteBookings = completeBookings,
                CancelledBookings = cancelledBookings
            };
            // Create a viewmodel to pass to view to sort tables with data// 
            return View(vm);
        }
    }
}