using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;

namespace DonaldsonMotorsThree.Controllers
{
    public class StockController : Controller
    {

       // Declare CarPart Repository
        private CarPartRepository repository;

        public StockController()
        {
            repository = new CarPartRepository();
        }

        // GET: Stock
        public ActionResult Index()
        {
            
            return View(repository.GetAll());
        }

        //GET: Stock/Details/1
        public ActionResult Details(int id)
        {
            if(id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(repository.Get(id));
        }

        public ActionResult Edit(int id)
        {

            return View();
        }



    }
}