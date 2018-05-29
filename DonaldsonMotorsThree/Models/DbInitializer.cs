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
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {

            if (!context.Users.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var userStore = new UserStore<User>(context);


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







                //Add User Role information for seed data//

                string userName = "donaldsonstoreadmin2410@gmail.com";
                string password = "DMadmin12$$";

                // Use Password Hasher to hash passwords for seed data // 
                  var passwordHash = new PasswordHasher();
                  password = passwordHash.HashPassword(password);


                //create Admin user and role//
                var user = userManager.FindByName(userName);
                if (user == null)
                {
                    List<string> qualList = new List<string>();
                    qualList.Add("Maths - A");
                    qualList.Add("English - A");
                    qualList.Add("Graphical Design - C");
                    qualList.Add("Business Studies - B");

                var newUser = new Staff()
                    {
                    // Staff member goes here// 
                        Email = userName,
                        PasswordHash = password,
                        
                        Dob = DateTime.Today,
                        MobileNumber = "07771110492",
                        EmergContactDetails = "07778120492",
                        MedContactDetails = "0141 0141 0141",
                        Qualifications = qualList,
                        NiNumber = "ABC-123-ZYX",
                        AreaOfExpertise = "",
                        Contracts = null
                    };

                    userManager.Create(newUser, password);
                    userManager.AddToRole(newUser.Id, "ADMIN");
                }


                //_________STAFF MEMBER 2- STORE MANAGER____________//
                var user2 = userManager.FindByName("dmstoremanager2410@gmail.com");
                if (user2 == null)
                {
                    List<string> qualList = new List<string>();
                    qualList.Add("Maths - B");
                    qualList.Add("English - A");
                    qualList.Add("Graphical Design - A");
                    qualList.Add("Business Studies - A");
                    var passwordSM = "StoreManager12$$";
                    passwordSM = passwordHash.HashPassword(passwordSM);

                    var newUser2 = new Staff()
                    {
                        //Initial Staff Member 2 goes here  //
                        Email = "dmstoremanager2410@gmail.com",
                        PasswordHash = passwordSM,
                     
                        Dob = DateTime.Today,
                        MobileNumber = "07771110492",
                        EmergContactDetails = "07778120492",
                        MedContactDetails = "0141 0141 0141",
                        Qualifications = qualList,
                        NiNumber = "ABC-123-ZYX",
                        AreaOfExpertise = "Store Management, Stock Control",
                        Contracts = null
                    };

                    userManager.Create(newUser2, "StoreManager12$$");
                    userManager.AddToRole(newUser2.Id, "STOREMANAGER");
                }




                //________________GARAGE MANAGER ROLE STAFF3____________________//
                var user3 = userManager.FindByName("DMGARAGEMANAGER2410@gmail.com");
                if (user3 == null)
                {
                    // Give staff member some initial data // 
                    List<string> qualList = new List<string>();
                    qualList.Add("Maths - A");
                    qualList.Add("English - A");
                    qualList.Add("Graphical Design - A");
                    qualList.Add("Business Studies - A");
                    qualList.Add("Business Management - Phd");
                    // Hash Password//
                    var passwordGM = "DMgarage2410$";
                    passwordGM = passwordHash.HashPassword(passwordGM);
                    var newStaff3 = new Staff()
                    {
                        // Staff member 3 goes here
                        Email = "DMGARAGEMANAGER2410@gmail.com",
                        PasswordHash = passwordGM,
                     
                        Dob = DateTime.Today,
                        MobileNumber = "07771110492",
                        EmergContactDetails = "07778120492",
                        MedContactDetails = "0141 0141 0141",
                        Qualifications = qualList,
                        NiNumber = "ABC-123-ZYX",
                        AreaOfExpertise = "Business extraordinaire, All Operations",
                        Contracts = null
                    };

                    userManager.Create(newStaff3, "DMgarage2410$");
                    userManager.AddToRole(newStaff3.Id, "GARAGEMANAGER");
                }

                //_____STAFF MEMBER 4- OFFICE STAFF_____//

                var user4 = userManager.FindByName("dmofficestaff2410@gmail.com");
                if (user4 == null)
                {
                    List<string> qualList = new List<string>();
                    qualList.Add("Maths - B");
                    qualList.Add("English - C");
                    qualList.Add("Graphical Design - C");
                    qualList.Add("Business Studies - B");
                    var passwordOS = "OfficeStaff2410$$";
                    passwordOS = passwordHash.HashPassword(passwordOS);

                    var newUser4 = new Staff()
                    {
                        //Initial Staff Member 4 goes here 
                        Email = "dmofficestaff2410@gmail.com",
                        PasswordHash = passwordOS,
           
                        Dob = DateTime.Today,
                        MobileNumber = "07771110492",
                        EmergContactDetails = "07778120492",
                        MedContactDetails = "0141 0141 0141",
                        Qualifications = qualList,
                        NiNumber = "ABC-123-ZYX",
                        AreaOfExpertise = "Office Duties, Jobs Control",
                        Contracts = null
                    };

                    userManager.Create(newUser4, "OfficeStaff2410$$");
                    userManager.AddToRole(newUser4.Id, "OFFICESTAFF");
                }




                //________________MECHANIC ROLE STAFF5____________________//
                var user5 = userManager.FindByName("DMMECHANICGary2410@gmail.com");
                if (user5 == null)
                {
                    // Give staff member5 some initial data // 
                    List<string> qualList = new List<string>();
                    qualList.Add("Maths - C");
                    qualList.Add("English - C");
                    qualList.Add("Graphical Design - C");
                    qualList.Add("Business Studies - C");
                    qualList.Add("Mechanics - Level 8");
                    // Hash Password//
                    var passwordM = "DMmechanic2410$";
                    passwordM = passwordHash.HashPassword(passwordM);
                    var newStaff5 = new Staff()
                    {
                        // Staff member 3 goes here
                        Email = "DMMECHANICGary2410@gmail.com",
                        PasswordHash = passwordM,
  
                        Dob = DateTime.Today,
                        MobileNumber = "07771110492",
                        EmergContactDetails = "07778120492",
                        MedContactDetails = "0141 0141 0141",
                        Qualifications = qualList,
                        NiNumber = "ABC-123-ZYX",
                        AreaOfExpertise = "Mechanics, Jobs",
                        Contracts = null
                    };

                    userManager.Create(newStaff5, "DMmechanic2410$");
                    userManager.AddToRole(newStaff5.Id, "MECHANIC");
                }




            }
            //_____________GIVE SEED DATA TO DbContext and Save Changes____________________//

            base.Seed(context);
            context.SaveChanges();
        }



    }
}