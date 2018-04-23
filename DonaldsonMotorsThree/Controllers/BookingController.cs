using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.ViewModels;

namespace DonaldsonMotorsThree.Controllers
{
    [AllowAnonymous]
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

        // GET: Booking/Create
        public ActionResult Create()
        {
            var jobs = _context.Jobs.ToList();
            var viewModel = new CreateBookingViewModel
            {
                Jobs = jobs
            };

            return View(viewModel);
        }


    }
}