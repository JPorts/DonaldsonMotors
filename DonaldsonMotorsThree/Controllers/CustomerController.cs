using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DonaldsonMotorsThree.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        // Declare Context and rerpository // 
        private ApplicationDbContext _context;
        private CustomerRepository repo;

        // Instantiate repo and context in constructor // 
        public CustomerController()
        {
            _context = new ApplicationDbContext();
            repo = new CustomerRepository();
        }


        // GET: Customer
        public ActionResult Index()
        {

            return View(repo.GetAll());
        }


        // GET: Customer/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }


        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (customer.CustomerId == 0)
                {
                    repo.Add(customer);
                    repo.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
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

        // GET: Customer/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
