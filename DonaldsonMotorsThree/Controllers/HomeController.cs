using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using DonaldsonMotorsThree.ViewModels;

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

        public ActionResult EditJob(int id)
        {
            // Get Job From Repo //
            var job = repository.Get(id);
            // Check If job is not null //
            if (job == null)
                return HttpNotFound();
            //Construct VM //
            var viewModel = new JobViewModel
            {
                Job = job
            };
            // Return View //
            return View("EditJob", viewModel);
        }

        //public ActionResult UpdateJob(int id)
        //{

        //    return;
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

            return View();
        }

    }
}