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
    public class ReportController : Controller
    {
        // Declare CarPart,Supplier Repository and Context

        private CarPartRepository PartRepo;
        private SupplierRepository SupplierRepo;
        private ApplicationDbContext _context;

        // Instantiate Repos and Context in Constructor // 
        public ReportController()
        {
            PartRepo = new CarPartRepository();
            SupplierRepo = new SupplierRepository();
            _context = new ApplicationDbContext();
        }


        // GET: Report
        public ActionResult GenerateReport()
        {
            return View();
        }

        public ActionResult StockReport()
        {
            var stock = PartRepo.GetAll().ToList();
            return View(stock);
        }

        public ActionResult ProductReport()
        {
            return View();
        }

        public ActionResult CustomersAndJobsReport()
        {
            return View();
        }

        public ActionResult DailyJobsList()
        {
            return View();
        }
    }
}