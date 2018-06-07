// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="HomeController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using DonaldsonMotorsThree.ViewModels;
using Microsoft.AspNet.Identity;

namespace DonaldsonMotorsThree.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [AllowAnonymous]
    public class HomeController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;
        /// <summary>
        /// The repository
        /// </summary>
        private JobRepository repository;

        private JobTypesRepository jobRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
        {
            jobRepo = new JobTypesRepository();
            repository = new JobRepository();
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            if (this.User.Identity.IsAuthenticated)
            {
                EnvironmentGlobals.UserId = userID;
                EnvironmentGlobals.IsCustomer = _context.Customers.Any(a => a.Id == userID);
            }
            return View();
        }


        /// <summary>
        /// Views the jobs.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ViewJobs()
        {
            ViewBag.Message = "Jobs";

            
            return View(jobRepo.GetAll());
        }
        /// <summary>
        /// Customers the view jobs.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult CustomerViewJobs()
        {
            ViewBag.Message = "Jobs";


            return View(jobRepo.GetAll());
        }
        /// <summary>
        /// Creates the job.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult CreateJob()
        {
            
            return View();
        }

        /// <summary>
        /// Adds the job.
        /// </summary>
        /// <param name="job">The job.</param>
        /// <returns>ActionResult.</returns>
        [System.Web.Http.HttpPost]
        public ActionResult AddJob(JobTypes job)
        {
            if (job.Id == 0)
                jobRepo.Add(job);
            repository.SaveChanges();
            return RedirectToAction("ViewJobs", "Home");
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int id)
        {
            // Get Job From Repo //
            var job = jobRepo.Get(id);
            // Check If job is not null //
            if (job == null)
                return HttpNotFound();
            //Construct VM //
            var viewModel = new JobViewModel
            {
                JobType = job
            };
            // Return View //
            return View("Edit", viewModel);
        }



        /// <summary>
        /// Mechanics the jobs.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult MechanicJobs()
        {

            return View();
        }


        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us.";

            return View();
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int id)
        {
            var jobDetails = jobRepo.Get(id);

            if (jobDetails == null)
                return HttpNotFound();
            var JobVM = new JobViewModel
            {
                JobType = jobDetails
            };

            return View(JobVM);
        }

    }
}