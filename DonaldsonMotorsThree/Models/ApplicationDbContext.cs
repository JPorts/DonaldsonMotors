// ***********************************************************************
// Assembly         : DonaldsonMotorsThree
// Author           : Jordan-P
// Created          : 06-06-2018
//
// Last Modified By : Jordan-P
// Last Modified On : 06-06-2018
// ***********************************************************************
// <copyright file="ApplicationDbContext.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DonaldsonMotorsThree.Models
{

    /// <summary>
    /// Class ApplicationDbContext.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{DonaldsonMotorsThree.Models.User}" />
    public class ApplicationDbContext : IdentityDbContext<User>
        {


        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the car parts.
        /// </summary>
        /// <value>The car parts.</value>
        public DbSet<CarPart> CarParts { get; set; }

        /// <summary>
        /// Gets or sets the jobs.
        /// </summary>
        /// <value>The jobs.</value>
        public DbSet<Job> Jobs { get; set; }

        /// <summary>
        /// Gets or sets the reviews.
        /// </summary>
        /// <value>The reviews.</value>
        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// Gets or sets the suppliers.
        /// </summary>
        /// <value>The suppliers.</value>
        public DbSet<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Gets or sets the staff.
        /// </summary>
        /// <value>The staff.</value>
        public DbSet<Staff> Staff { get; set; }

        /// <summary>
        /// Gets or sets the bookings.
        /// </summary>
        /// <value>The bookings.</value>
        public DbSet<Booking> Bookings { get; set; }

        /// <summary>
        /// Gets or sets the vehicle details.
        /// </summary>
        /// <value>The vehicle details.</value>
        public DbSet<VehicleDetails> VehicleDetails { get; set; }

        /// <summary>
        /// Gets or sets the baskets.
        /// </summary>
        /// <value>The baskets.</value>
        public DbSet<Basket> Baskets { get; set; }

        /// <summary>
        /// Gets or sets the basket items.
        /// </summary>
        /// <value>The basket items.</value>
        public DbSet<BasketItem> BasketItems { get; set; }

        /// <summary>
        /// Gets or sets the job types.
        /// </summary>
        /// <value>The job types.</value>
        public DbSet<JobTypes> JobTypes { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()

                    : base("DonaldsonMotorsDb", throwIfV1Schema: false)
                {
                    Database.SetInitializer(new DbInitializer());

                }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ApplicationDbContext.</returns>
        public static ApplicationDbContext Create()
                {
                    return new ApplicationDbContext();
                }

        /// <summary>
        /// Gets or sets the role view models.
        /// </summary>
        /// <value>The role view models.</value>
        public System.Data.Entity.DbSet<DonaldsonMotorsThree.ViewModels.RoleViewModel> RoleViewModels { get; set; }
    }
           
        }
    
