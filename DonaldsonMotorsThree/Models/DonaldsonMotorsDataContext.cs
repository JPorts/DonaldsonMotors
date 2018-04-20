using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DonaldsonMotorsThree.Models
{
    public class DonaldsonMotorsDataContext : DbContext
    {

        public DonaldsonMotorsDataContext(): base("name=DonaldsonMotorsDb")
        {
        }

        public DbSet<CarPart> CarParts { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }





    }
}