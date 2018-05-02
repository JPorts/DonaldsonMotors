using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Controllers
{
    

    [Authorize]
    public class StaffController : Controller
    {
        // Declare Db Context 
        private ApplicationDbContext _context;

        public StaffController()
        {

            _context = new ApplicationDbContext();
        }

        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: Staff/Create
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.Roles, "Id", "Name");

            
            return View();
        }


        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult ManageJobs()
        {

            return View();
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
