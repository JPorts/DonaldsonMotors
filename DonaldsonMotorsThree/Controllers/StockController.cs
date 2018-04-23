using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data.SqlClient;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;

namespace DonaldsonMotorsThree.Controllers
{
    public class StockController : Controller
    {
       // private ApplicationDbContext _context = new ApplicationDbContext();
       CarPartRepository repository = new CarPartRepository();

        // GET: Stock
        public ActionResult Index()
        {
            
            return View(repository.GetAll());
        }
    }
}