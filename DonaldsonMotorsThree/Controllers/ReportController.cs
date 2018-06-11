// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="ReportController.cs" company="">
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

namespace DonaldsonMotorsThree.Controllers
{
    /// <summary>
    /// Class ReportController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ReportController : Controller
    {
        // Declare CarPart,Supplier Repository and Context

        /// <summary>
        /// The part repo
        /// </summary>
        private CarPartRepository PartRepo;
        /// <summary>
        /// The supplier repo
        /// </summary>
        private SupplierRepository SupplierRepo;
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;

        // Instantiate Repos and Context in Constructor // 
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportController" /> class.
        /// </summary>
        public ReportController()
        {
            PartRepo = new CarPartRepository();
            SupplierRepo = new SupplierRepository();
            _context = new ApplicationDbContext();
        }


        // GET: Report
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult GenerateReport()
        {
            return View();
        }

        /// <summary>
        /// Stocks the report.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult StockReport()
        {
            var stock = PartRepo.GetAll().ToList();
            return View(stock);
        }

        /// <summary>
        /// Products the report.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ProductReport()
        {
            var carparts = PartRepo.GetAll();

            return View(carparts);
        }

        /// <summary>
        /// Customerses the and jobs report.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult CustomersAndJobsReport()
        {
            ///
            /// Staff Member must be logged into the system. Report generated must include:
                //	Job ID
                //	Date of Invoice
                //	Job Total Cost
               //Customer ID
                //Overall Totals by Customer/ Job
            var Jobs = _context.Jobs.ToList();
            var Customers = _context.Customers.ToList();
            var CustomersWithJobs = Customers.Where(c => c.Bookings != null);

            foreach(var customer in Customers) {
                
            }

            return View();
        }

        /// <summary>
        /// Dailies the jobs list.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult DailyJobsList()
        {
            var jobList = _context.Jobs.Where(j => j.StartDate == DateTime.Today);                
            return View(jobList);
        }
    }
}