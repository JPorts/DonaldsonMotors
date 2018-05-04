using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using DonaldsonMotorsThree.ViewModels;

namespace DonaldsonMotorsThree.Controllers
{
    

    [Authorize]
    public class StaffController : Controller
    {
        // Declare Db Context and repos
        private ApplicationDbContext _context;
        private StaffRepository staffRepo;

        public StaffController()
        {
            staffRepo = new StaffRepository();
            _context = new ApplicationDbContext();
        }

        // GET: Staff
        public ActionResult Index()
        {
            var ViewAll = staffRepo.GetAll();
            return View(ViewAll);
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            var staff = staffRepo.Get(id);
            if (staff == null)
                return HttpNotFound();


            return View(staff);
        }
        
        // POST: Staff/Create
     
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.Roles, "Id", "Name");
            
            
            return View();
        }

        [HttpPost]
        public ActionResult AddStaff(Staff staff)
        {
            // if employee id isn't assigned, add new staff member using staffRepo //
            if(staff.EmployeeId == 0)
                staffRepo.Add(staff);
                staffRepo.SaveChanges();

            return RedirectToAction("Index", "Staff");
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
