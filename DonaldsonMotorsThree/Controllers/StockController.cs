using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data.SqlClient;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Controllers
{
    public class StockController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
       

        // GET: Stock
        public ActionResult Index()
        {
            var partList = context.CarParts.ToList();
            return View(partList);
        }
    }
}