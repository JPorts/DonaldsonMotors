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
    public class BookingDataController : ApiController
    {
        private ApplicationDbContext _context;

        public BookingDataController()
        {
            _context = new ApplicationDbContext();
        }



        [HttpPost]
        public IHttpActionResult CreateBooking(BookingDto bookingDto)
        {
            //
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == bookingDto.Customer.CustomerId);

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

                // find part required for job completion
                var part = _context.CarParts.Find(job.PartId);

                // check part quantity is available
                if (part.CurrentQuantity == 0)
                    return BadRequest("Parts needed are currently not available.");
                // Take away one from quantity of part//
                part.CurrentQuantity--;

                // Create initial booking object // 
                var booking = new Booking
                {
                    Customer = customer,
                    Job = job
                };
                _context.Bookings.Add(booking);
            }
            //
            return Ok();
        }
    }
}
