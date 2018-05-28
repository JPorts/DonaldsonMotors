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
                    Id = new Guid().ToString(),
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

       
    }
}
