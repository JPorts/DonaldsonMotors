using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DonaldsonMotorsThree.ViewModels;

namespace DonaldsonMotorsThree.Controllers
{
    [System.Web.Mvc.Authorize]
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
            var customers = repo.GetAll();
        
            return View(customers);
        }


        // GET: Customer/Details/5
        public ActionResult Details(string id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerViewModel
            {
                Customer = customer
            };
            return View("Details", viewModel);
        }


        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                
                    repo.Add(customer);
                    repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerViewModel
            {
                Customer = customer
            };
            return View("Edit", viewModel);
        }

        // POST: Customer/Edit/5
        [System.Web.Mvc.HttpPost]
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
        [System.Web.Mvc.HttpPost]
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

        //Dispose of db//
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}
