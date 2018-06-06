// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="StockController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class StockController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class StockController : Controller
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
        /// Initializes a new instance of the <see cref="StockController"/> class.
        /// </summary>
        public StockController()
        {
            PartRepo = new CarPartRepository();
            SupplierRepo = new SupplierRepository();
            _context = new ApplicationDbContext();
        }

        // GET: Stock
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var parts = PartRepo.GetAll();

            if (User.IsInRole("Customer") || User.Identity.IsAuthenticated == false)
                return View("CustomerIndex", parts);

            return View(parts);
        }

        /// <summary>
        /// Customers the index.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult CustomerIndex()
        {
            return View(PartRepo.GetAll());
        }

        //GET: Stock/Details/1
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int id)
        {
            var carPart = PartRepo.Get(id);

            if (carPart == null)
                return HttpNotFound();


            return View(carPart);
        }


        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
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


        /// <summary>
        /// Creates the car part.
        /// </summary>
        /// <returns>ActionResult.</returns>
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
        /// <summary>
        /// Adds the car part.
        /// </summary>
        /// <param name="carPart">The car part.</param>
        /// <param name="supplier">The supplier.</param>
        /// <returns>ActionResult.</returns>
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