// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="SupplierController.cs" company="">
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

namespace DonaldsonMotorsThree.Controllers
{
    /// <summary>
    /// Class SupplierController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class SupplierController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;
        /// <summary>
        /// The repo
        /// </summary>
        private SupplierRepository repo;
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierController"/> class.
        /// </summary>
        public SupplierController()
        {
            repo = new SupplierRepository();
            _context= new ApplicationDbContext();
        }


        // GET: Supplier
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var suppliers = repo.GetAll();
            return View(suppliers);
        }


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            
            return View();
        }
        // POST: Supplier/create 
        /// <summary>
        /// Creates the supplier.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult CreateSupplier()
        {

            return View();
        }

        // GET: Supplier/Edit/1
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int id)
        {
            var supplier = repo.Get(id);

            if (supplier == null)
                return HttpNotFound();
            
            return View(supplier);
        }

        // : Supplier/Delete/1
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int id)
        {
            var supplier = repo.Get(id);

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();

            if (supplier == null)
                return HttpNotFound();

            return View(supplier);
        }

        // GET: Supplier/Details/1
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int id)
        {
            var supplier = repo.Get(id);

            if (supplier == null)
                return HttpNotFound();

            return View(supplier);
        }
    }
}