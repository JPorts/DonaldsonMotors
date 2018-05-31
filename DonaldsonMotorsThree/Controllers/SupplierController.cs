using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;

namespace DonaldsonMotorsThree.Controllers
{
    public class SupplierController : Controller
    {
        private ApplicationDbContext _context;
        private SupplierRepository repo;
        public SupplierController()
        {
            repo = new SupplierRepository();
            _context= new ApplicationDbContext();
        }


        // GET: Supplier
        public ActionResult Index()
        {
            var suppliers = repo.GetAll();
            return View(suppliers);
        }


        public ActionResult Create()
        {
            
            return View();
        }
        // POST: Supplier/create 
        [HttpPost]
        public ActionResult CreateSupplier()
        {

            return View();
        }

        // GET: Supplier/Edit/1
        public ActionResult Edit(int id)
        {
            var supplier = repo.Get(id);

            if (supplier == null)
                return HttpNotFound();
            
            return View(supplier);
        }

        // : Supplier/Delete/1
        public ActionResult Delete(int id)
        {
            var supplier = repo.Get(id);

            if (supplier == null)
                return HttpNotFound();

            return View(supplier);
        }

        // GET: Supplier/Details/1
        public ActionResult Details(int id)
        {
            var supplier = repo.Get(id);

            if (supplier == null)
                return HttpNotFound();

            return View(supplier);
        }
    }
}