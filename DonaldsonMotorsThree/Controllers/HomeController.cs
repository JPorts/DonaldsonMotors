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

        public ActionResult CreateJob()
        {
            
            return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult AddJob(Job job)
        {
            if (job.JobId == 0)
                repository.Add(job);
            repository.SaveChanges();
            return RedirectToAction("ViewJobs", "Home");
        }

        public ActionResult Edit(int id)
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
            return View("Edit", viewModel);
        }






        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

            return View();
        }

        public ActionResult Details(int id)
        {
            var jobDetails = repository.Get(id);

            if (jobDetails == null)
                return HttpNotFound();
            var JobVM = new JobViewModel
            {
                Job = jobDetails
            };

            return View(JobVM);
        }

    }
}