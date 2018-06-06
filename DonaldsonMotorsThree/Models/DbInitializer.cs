// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="DbInitializer.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DonaldsonMotorsThree.Models
{
    /// <summary>
    /// Class DbInitializer.
    /// </summary>
    /// <seealso cref="System.Data.Entity.CreateDatabaseIfNotExists{DonaldsonMotorsThree.Models.ApplicationDbContext}" />
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {

        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(ApplicationDbContext context)
        {

            if (!context.Users.Any())
            {
                SeedDB.Seed(context);
                base.Seed(context);
                context.SaveChanges();
            }
        }
    }
}