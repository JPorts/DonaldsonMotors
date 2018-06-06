// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="ReviewController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DonaldsonMotorsThree.Controllers
{
    /// <summary>
    /// Class ReviewController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ReviewController : Controller
    {
        // Declare repo and context // 
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;
        /// <summary>
        /// The repo
        /// </summary>
        private ReviewRepository repo;

        // Instantiate repo and context in constructor // 

        // GET: Review
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
           // var reviews = repo.GetAll().ToList();
            return View();
        }
        // GET: Review
        /// <summary>
        /// Admins the index.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AdminIndex()
        {

            return View();
        }
        // GET: Review/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Details(int id)
        {
            return View();
        }



        // POST: Review/Create
        /// <summary>
        /// Creates the post.
        /// </summary>
        /// <param name="review">The review.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult CreatePost(Review review)
        {
            var userId = User.Identity.GetUserId();

            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            if (ModelState.IsValid)
            {
                review.User = user;
                review.Id = userId;
                review.PostDate = DateTime.Now;
                repo.Add(review);
            }      

                return View("Index");
            
           
        }

        // GET: Review/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collection">The collection.</param>
        /// <returns>ActionResult.</returns>
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
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collection">The collection.</param>
        /// <returns>ActionResult.</returns>
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
