﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DonaldsonMotorsThree.Models
{

        public class ApplicationDbContext : IdentityDbContext<User>
        {
        

                public DbSet<Customer> Customers { get; set; }

                public DbSet<CarPart> CarParts { get; set; }

                public DbSet<Job> Jobs { get; set; }

                public DbSet<Supplier> Suppliers { get; set; }

                public DbSet<Staff> Staff { get; set; }
                
                public DbSet<Booking> Bookings { get; set; }

                public ApplicationDbContext()

                    : base("DonaldsonMotorsDb", throwIfV1Schema: false)
                {
                    Database.SetInitializer(new DbInitializer());

                }

                public static ApplicationDbContext Create()
                {
                    return new ApplicationDbContext();
                }

        
    }
           
        }
    