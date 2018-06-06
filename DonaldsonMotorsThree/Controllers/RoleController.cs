// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="RoleController.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Models;
using DonaldsonMotorsThree.ViewModels;
using Microsoft.AspNet.Identity.Owin;

namespace DonaldsonMotorsThree.Controllers
{
    /// <summary>
    /// Class RoleController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class RoleController : Controller
    {
        /// <summary>
        /// The role manager
        /// </summary>
        private ApplicationRoleManager _roleManager;




        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        public RoleController()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        /// <param name="roleManager">The role manager.</param>
        public RoleController(ApplicationRoleManager roleManager)
        {
 
            RoleManager = roleManager;
        }
        /// <summary>
        /// Gets the role manager.
        /// </summary>
        /// <value>The role manager.</value>
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Role
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();

            foreach (var role in RoleManager.Roles)
            {
                list.Add(new RoleViewModel(role));
            }
            return View(list);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole() {Name = model.Name};
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        public async Task<ActionResult> Edit(string Id)
        {
            var role = await RoleManager.FindByIdAsync(Id);
            return View(new RoleViewModel(role));
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = new ApplicationRole() {Id = model.Id, Name = model.Name};
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        public async Task<ActionResult> Details(string Id)
        {
            var role = await RoleManager.FindByIdAsync(Id);
            return View(new RoleViewModel(role));

        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        public async Task<ActionResult> Delete(string Id)
        {
            var role = await RoleManager.FindByIdAsync(Id);
            return View(new RoleViewModel(role));
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        public async Task<ActionResult> DeleteConfirmed(string Id)
        {
            var role = await RoleManager.FindByIdAsync(Id);
            await RoleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }
    }
}