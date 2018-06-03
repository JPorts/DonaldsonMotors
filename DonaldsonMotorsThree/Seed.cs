using DonaldsonMotorsThree.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree
{
    public static class SeedDB
    {
        public static void Seed(ApplicationDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false) System.Diagnostics.Debugger.Launch();
            //System.Diagnostics.Debugger.Break;

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var userStore = new UserStore<User>(context);

            PopulateRoles(roleManager);


            // Create Staff 
            CreateStaffUser(userManager, GetStaffTemplate("Staff1@gmail.com"), Constants.Roles.Administrator);
            CreateStaffUser(userManager, GetStaffTemplate("Staff2@gmail.com"), Constants.Roles.GarageManager);
            CreateStaffUser(userManager, GetStaffTemplate("Staff3@gmail.com"), Constants.Roles.Mechanic);
            CreateStaffUser(userManager, GetStaffTemplate("Staff4@gmail.com"), Constants.Roles.OfficeStaff);
            CreateStaffUser(userManager, GetStaffTemplate("Staff5@gmail.com"), Constants.Roles.StoreManager);

            CreateCustomerUser(userManager, GetCustomerTemplate("jimmy.cobb@gmail.com", "jim", "cobb"));
            CreateCustomerUser(userManager, GetCustomerTemplate("barry.tickler@gmail.com", "barry", "tickler"));
            CreateCustomerUser(userManager, GetCustomerTemplate("John.Popper@gmail.com", "John", "Popper"));
            CreateCustomerUser(userManager, GetCustomerTemplate("bob.scriggins@gmail.com", "bob", "scriggins"));

            CreateJobTypes(context); 

            //_____________GIVE SEED DATA TO DbContext and Save Changes____________________//

            //base.Seed(context);
            context.SaveChanges();

        }

        private static void CreateJobTypes(ApplicationDbContext context)
        {
            if (!context.JobTypes.Any())
            {
                context.JobTypes.Add(new JobTypes { JobRequirements = "MOT Test", JobCost = 120.00 });
                context.JobTypes.Add(new JobTypes { JobRequirements = "Wheel Re-alignment", JobCost = 120.00 });
                context.JobTypes.Add(new JobTypes { JobRequirements = "Replace Shocks", JobCost = 250.00 });
                context.JobTypes.Add(new JobTypes { JobRequirements = "Engine Remap - Powerhouse", JobCost = 1150.00 });
                context.JobTypes.Add(new JobTypes { JobRequirements = "Engine Remap - Eco", JobCost = 900.00 });
                context.SaveChanges();
            }
        }

        private static Customer GetCustomerTemplate(string userName, string firstName, string lastName)
        {
            return new Customer()
            {
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                AddressLine1 = "2 Nowhere Rd",
                AddressLine2 = "Glasgow",
                Email = userName,
                PhoneNumber = "07771110492",
                TelephoneNumber = "07771110492",
                Postcode = "G72 5PQ",
                Town = "Clydebank"
            };
        }

        private static Staff GetStaffTemplate(string userName)
        {
            return new Staff()
            {
                FirstName = "Staff",
                LastName = "Member",
                AddressLine1 = "Donaldsons Garage",
                AddressLine2 = "Donaldson Road",
                Town = "Glasgow",
                Postcode = "G52 2HQ",
                PhoneNumber = "0141 100 200",
                TelephoneNumber = "0141 100 200",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                Email = userName,
                UserName = userName,
                Dob = DateTime.Today,
                MobileNumber = "07771110492",
                EmergContactDetails = "07778120492",
                MedContactDetails = "0141 0141 0141",
                Qualifications = new List<string> { "Maths - A", "English - A", "Graphical Design - C", "Business Studies - B" },
                NiNumber = "ABC-123-ZYX",
                AreaOfExpertise = "Mechanics",
                Contracts = null
            };
        }
        private static void CreateCustomerUser(UserManager<User> userManager, Customer newUser)
        {
            var user = userManager.FindByName(newUser.UserName);
            if (user == null)
            {
                //Add User Role information for seed data//
                string password = "R4ng3rs!";

                // Use Password Hasher to hash passwords for seed data // 
                var passwordHash = new PasswordHasher();
                password = passwordHash.HashPassword(password);

                //newUser.PasswordHash = password; 
                var result = userManager.Create(newUser, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(newUser.Id, Constants.Roles.Customer);
                }
            }
        }



        private static void CreateStaffUser(UserManager<User> userManager, Staff newUser, string roleName)
        {
            // Hash password using password hasher // 
            var passwordHasher = new PasswordHasher();

            var user = userManager.FindByName(newUser.UserName);
            if (user == null)
            {
                //Add User Role information for seed data//
                var password = "R4ng3rs!";
                newUser.Rolename = roleName;
                // Use Password Hasher to hash passwords for seed data // 
                password = passwordHasher.HashPassword(password);
                newUser.PasswordHash = password; 


                var result = userManager.Create(newUser, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(newUser.Id, roleName);
                }
            }
        }

        private static void PopulateRoles(RoleManager<IdentityRole> roleManager)
        {
            //Populating the Role table with user roles //
            if (!roleManager.RoleExists("Garage Manager"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Garage Manager"));
            }

            if (!roleManager.RoleExists("Mechanic"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Mechanic"));
            }

            if (!roleManager.RoleExists("Store Manager"))
            {

                var roleresult = roleManager.Create(new IdentityRole("Store Manager"));
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Customer"));
            }

            if (!roleManager.RoleExists("Corporate Customer"))
            {
                var roleresult = roleManager.Create(new IdentityRole("Corporate Customer"));
            }

            if (!roleManager.RoleExists("Office Staff"))
            {

                var roleresult = roleManager.Create(new IdentityRole("Office Staff"));
            }
            if (!roleManager.RoleExists("Administrator"))
            {

                var roleresult = roleManager.Create(new IdentityRole("Administrator"));
            }
        }

    }
}