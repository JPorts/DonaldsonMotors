// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="BookingDataController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Controllers.Api
{
    /// <summary>
    /// Class to control Data Services around booking functions.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BookingDataController : ApiController
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingDataController"/> class.
        /// </summary>
        public BookingDataController()
        {
            _context = new ApplicationDbContext();
        }



        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="bookingDto">The booking dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult CreateBooking(BookingDto bookingDto)
        {
            // check if inputs are valid// 
            var customer = _context.Customers.SingleOrDefault(c => c.Id == bookingDto.Customer.Id);

            if (customer == null)
                return BadRequest("Customer Id is not valid.");

            var jobs = _context.Jobs.Where(j => bookingDto.JobIds.Contains(j.JobId)).ToList();

            if (bookingDto.JobIds.Count == 0)
                return BadRequest("Must add a job to continue.");

            if (jobs.Count != bookingDto.JobIds.Count)
                return BadRequest("One or more Ids are invalid");


            // for each job selected in booking process
            foreach (var job in jobs)
            {

                foreach (CarPart p in job.Parts)
                {

                    // check part quantity is available
                    if (p.CurrentQuantity == 0)
                        return BadRequest("Parts needed are currently not available.");
                    // Take away one from quantity of part//
                    p.CurrentQuantity--;
                }

                // Create initial booking object // 
                var booking = new Booking
                {
                    Customer = customer,
                    StartDate = (DateTime)bookingDto.StartDate,
                };
                _context.Bookings.Add(booking);
            }
            //
            return Ok();
        }
    }
}
