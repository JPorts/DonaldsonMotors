// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="CustomerController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
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
        /// <summary>
        /// Class ConfirmedBookingController.
        /// </summary>
        /// <seealso cref="System.Web.Mvc.Controller" />
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
                /// <summary>
                /// Charges the specified stripe email.
                /// </summary>
                /// <param name="stripeEmail">The stripe email.</param>
                /// <param name="stripeToken">The stripe token.</param>
                /// <returns>ActionResult.</returns>
                return HttpNotFound();
            var viewModel = new CustomerViewModel
            {
                Customer = customer
            };
            return View("Details", viewModel);
        }

        [System.Web.Mvc.HttpPost]
        // GET: Customer/Create
        public ActionResult UpdateCustomer(CustomerViewModel vm)
        {
            var upd = vm.Customer; 

                var customer = _context.Customers.SingleOrDefault(c => c.Id == vm.Customer.Id);
                if (customer != null)
                {
                    customer.FirstName = upd.FirstName;
                    customer.LastName = upd.LastName;
                    customer.AddressLine1 = upd.AddressLine1;
                    customer.AddressLine2 = upd.AddressLine2;
                    customer.Town = upd.Town;
                    customer.Postcode = upd.Postcode;
                    customer.TelephoneNumber = upd.TelephoneNumber;

                _context.SaveChanges();
                }

            var newVm = new CustomerViewModel();
            newVm.Customer = customer; 
            

            return View("Details", newVm);
        }

        // POST: Customer/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                
                    repo.Add(customer);
                    repo.SaveChanges();
                /// <summary>
                /// Creates this instance.
                /// </summary>
                /// <returns>ActionResult.</returns>
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
