﻿using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonaldsonMotorsThree.Controllers
{
    public class ReviewController : Controller
    {
        // Declare repo and context // 
        private ApplicationDbContext _context;
        private ReviewRepository repo;

        // Instantiate repo and context in constructor // 

        // GET: Review
        public ActionResult Index()
        {
            var reviews = repo.GetAll();
            if (reviews == null)
                return View();
            return View(reviews);
        }
        // GET: Review
        public ActionResult AdminIndex()
        {

            return View();
        }
        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(Review Review)
        {
            if (ModelState.IsValid)
            {
                
                Review.PostDate = DateTime.Now;
                repo.Add(Review);
            }
                

                
                

                return RedirectToAction("Index");
            
           
                return View();
           
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
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

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
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
