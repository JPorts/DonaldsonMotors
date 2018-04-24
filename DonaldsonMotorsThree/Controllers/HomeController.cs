using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;

namespace DonaldsonMotorsThree.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private JobRepository repository;
       
        public HomeController()
        {
            repository = new JobRepository();
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewJobs()
        {
            ViewBag.Message = "Jobs";

            
            return View(repository.GetAll());
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

            return View();
        }

    }
}