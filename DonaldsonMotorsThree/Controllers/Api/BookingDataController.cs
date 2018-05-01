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
            var customer = _context.Customers.Single(c => c.CustomerId == bookingDto.Customer.CustomerId);
            var jobs = _context.Jobs.Where(j => bookingDto.JobIds.Contains(j.JobId));
            //
            foreach (var job in jobs)
            {
                var part = _context.CarParts.Find(job.PartId);
               // part.
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
