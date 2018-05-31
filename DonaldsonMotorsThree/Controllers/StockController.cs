using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;
using AutoMapper;
using DonaldsonMotorsThree.Controllers.Api;
using DonaldsonMotorsThree.Dtos;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using DonaldsonMotorsThree.ViewModels;

namespace DonaldsonMotorsThree.Controllers
{
    public class StockController : Controller
    {

       // Declare CarPart,Supplier Repository and Context

        private CarPartRepository PartRepo;
        private SupplierRepository SupplierRepo;
        private ApplicationDbContext _context;

        // Instantiate Repos and Context in Constructor // 
        public StockController()
        {
            PartRepo = new CarPartRepository();
            SupplierRepo = new SupplierRepository();
            _context = new ApplicationDbContext();
        }

        // GET: Stock
        public ActionResult Index()
        {
            
            return View(PartRepo.GetAll());
        }

        public ActionResult CustomerIndex()
        {
            return View(PartRepo.GetAll());
        }

        //GET: Stock/Details/1
        public ActionResult Details(int id)
        {
            var carPart = PartRepo.Get(id);

            if (carPart == null)
                return HttpNotFound();


            return View(carPart);
        }

       
        public ActionResult Edit(int id)
        {
            var carPart = PartRepo.Get(id);

            if (carPart == null)
                return HttpNotFound();

            var viewModel = new CarPartViewModel
            {
                CarPart = carPart,
                Suppliers = SupplierRepo.GetAll()

            };
            return View("Edit", viewModel);
        }


        public ActionResult CreateCarPart()
        {
            var Suppliers = SupplierRepo.GetAll();
            var viewModel = new CarPartViewModel
            {
                Suppliers = Suppliers
            };
            return View(viewModel);
        }

        // HTTP POST Which adds Car Part to the Table // 
        [System.Web.Http.HttpPost]
        public ActionResult AddCarPart(CarPart carPart, Supplier supplier)
        {
            // Make sure supplier Ids is the same as carpart supplier id // 
            carPart.SupplierId = supplier.SupplierId;
            // if Id == 0 use repo pattern to add carpart and save changes //
            if(carPart.PartId == 0)
                PartRepo.Add(carPart);           
                 PartRepo.SaveChanges();
            return RedirectToAction("Index", "Stock");
        }



    }
}