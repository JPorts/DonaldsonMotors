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
                SeedDB.Seed(context);
                base.Seed(context);
                context.SaveChanges();
            }
        }
    }
}