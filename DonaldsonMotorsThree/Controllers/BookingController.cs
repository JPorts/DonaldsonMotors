using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.ViewModels;
using Microsoft.AspNet.Identity;

namespace DonaldsonMotorsThree.Controllers
{
    [System.Web.Mvc.AllowAnonymous]
    public class BookingController : Controller
    {

        private ApplicationDbContext _context;


        public BookingController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }


        // POST: Booking/Create
        [System.Web.Http.HttpPost]
        public ActionResult Create()
        {
            //// If Model is not valid, throw bad request //
            //if(!ModelState.IsValid)
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);

            //// Grab customer from DB // 
            //var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);

            //// If Customer is null, through not found //
            //if(customer == null)
            //    throw new HttpResponseException(HttpStatusCode.NotFound);

            

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