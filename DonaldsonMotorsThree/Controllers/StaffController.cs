// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="StaffController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using DonaldsonMotorsThree.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DonaldsonMotorsThree.Controllers
{


    //[Authorize]
    /// <summary>
    /// Class StaffController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class StaffController : Controller
    {
        // Declare Db Context and repos
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;
        /// <summary>
        /// The staff repo
        /// </summary>
        private StaffRepository staffRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffController" /> class.
        /// </summary>
        public StaffController()
        {
            staffRepo = new StaffRepository();
            _context = new ApplicationDbContext();
        }
        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }


        //[HttpPost]
        //public ActionResult AddStaff()
        //{
        //    if (ModelState.IsValid)
        //    {
        //    }

        //    return null;
        //}

        /// <summary>
        /// Adds the staff.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <param name="form">The form.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult AddStaff(Staff staff, FormCollection form)
        {
            if (ModelState.IsValid)
            {

                // Hash password using password hasher // 
                var passwordHasher = new PasswordHasher();
                var password = passwordHasher.HashPassword(staff.Password);

                string roleName = form["Roles"].ToString();


                // Create new Customer Object // 
                var user = new Staff
                {
                    UserName = staff.Email,
                    Email = staff.Email,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    AddressLine1 = staff.AddressLine1,
                    AddressLine2 = staff.AddressLine2,
                    Town = staff.Town,
                    Postcode = staff.Postcode,
                    Dob = staff.Dob,
                    TelephoneNumber = staff.TelephoneNumber,
                    MobileNumber = staff.MobileNumber,
                    AreaOfExpertise = staff.AreaOfExpertise,
                    EmergContactDetails = staff.EmergContactDetails,
                    MedContactDetails = staff.MedContactDetails,
                    NiNumber = staff.NiNumber,
                    PasswordHash = password,
                    Rolename = staff.Rolename
                };

                var Account = new AccountController();
                Account.UserManager.AddToRole(user.Id, user.Rolename);
                _context.Users.Add(user);

                return View("Index");

            }

            return View("Create");
        }


        // GET: Staff
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var ViewAll = staffRepo.GetAll();
            return View(ViewAll);
        }

        // GET: Staff/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(string id)
        {
            var staff = _context.Staff.SingleOrDefault(s => s.Id == id);
            if (staff == null)
                return HttpNotFound();


            return View(staff);
        }

        // POST: Staff/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.Roles, "Id", "Name");
            
            
            return View();
        }

        //DELETE VIEW//
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(string id)
        {
            var staff = _context.Staff.SingleOrDefault(s => s.Id == id);

            return View(staff);
        }

        //DELETE
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult DeleteConfirmed(string id)
        {
            var staff = _context.Staff.SingleOrDefault(s => s.Id == id);
                _context.Staff.Remove(staff);
                _context.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(string id)
        {
            var staff = _context.Staff.SingleOrDefault(s => s.Id == id);

            return View(staff);
        }

        [HttpPost]
        public ActionResult UpdateStaff(Staff staff, FormCollection form)
        {

            if (ModelState.IsValid)
            {
                var staffToUpdate = _context.Staff.Find(staff.Id);

                _context.Entry(staffToUpdate).CurrentValues.SetValues(staff);
                _context.SaveChanges();
            }
           return RedirectToAction("Index");
        }


    }
}
