using DonaldsonMotorsThree.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Roles.AddOrUpdate(r => r.Name,
            //    new IdentityRole {Name = "Administrator" },
            //    new IdentityRole { Name = "Customer" },
            //    new IdentityRole { Name = "CorporateCustomer" },
            //    new IdentityRole { Name = "Mechanic" },
            //    new IdentityRole { Name = "Staff" },
            //    new IdentityRole { Name = "OfficeStaff" },
            //    new IdentityRole { Name = "StoreManager" },
            //    new IdentityRole { Name = "GarageManager" }
            //    );

            // Create new Role manager by passing in Identity Role and and new Rolestore // 
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // Construct a string array or roles in the system // 
            string[] roleNames = { "Administrator", "Customer", "CorporateCustomer", "Mechanic", "Staff", "OfficeStaff", "StoreManager", "GarageManager" };

            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                if (!roleManager.RoleExists(roleName))
                {
                    roleResult = roleManager.Create(new IdentityRole(roleName));
                }
            }
            // Create a userManager // 
            var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.AddToRole("f522893e-72be-4d0d-bcf5-931067dace54", "Administrator");
        }
    }
}
