using DonaldsonMotorsThree.Models;

namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DonaldsonMotorsThree.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DonaldsonMotorsThree.Models.ApplicationDbContext";
        }


        protected override void Seed(DonaldsonMotorsThree.Models.ApplicationDbContext context)
        {
          
            // Adding Suppliers Context To Db Initializer // 
            context.Suppliers.AddOrUpdate(
                p => p.SupplierId,
                    new Supplier { SupplierName = "Matheson", AddressLine1 = "2 Wallace Street", AddressLine2 = "Anderston", ContactName = "Sonny", EmailAddress = "mathesonsonny@gmail.com", Postcode = "G65 0NR", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" },
                    new Supplier { SupplierName = "Dhillons", AddressLine1 = "2 Almond Avenue", AddressLine2 = "Elmsley", ContactName = "Jack", EmailAddress = "jackalmonddhillons@gmail.com", Postcode = "G12 0ER", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" },
                    new Supplier { SupplierName = "ACME", AddressLine1 = "ACME House", AddressLine2 = "15 Main Street", ContactName = "Heather", EmailAddress = "heatheracmehouse15@gmail.com", Postcode = "AC ME", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" },
                    new Supplier { SupplierName = "Oil Wholesale", AddressLine1 = "221 Albert Crescent", AddressLine2 = "Cambridge", ContactName = "Vladimir", EmailAddress = "vladoilwholesalecam@gmail.com", Postcode = "CA1 0ZX", TelephoneNumber = "1233 7458 9456", Town = "Cambridge" },
                    new Supplier { SupplierName = "Brand Mechanics", AddressLine1 = "84 Daisy Road", AddressLine2 = "Inverallan", ContactName = "Chad", EmailAddress = "ahmedsupplierm@gmail.com", Postcode = "G5 9JU", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" },
                    new Supplier { SupplierName = "REueters", AddressLine1 = "25 Amolie Street", AddressLine2 = "Applesby", ContactName = "Arthur", EmailAddress = "ArtherApplesbyAmolie@gmail.com", Postcode = "G6 5JQ", TelephoneNumber = "1233 7458 9456", Town = "Applesby" }
                );


            // Adding CarParts To Db Initializer //
            context.CarParts.AddOrUpdate(
                p => p.PartId,
                    new CarPart { Name = "Wrench", Colour = "Red", Description = "A Red Wrench to get the job done !", Price = 10, ReorderLevel = 10, ReorderQuantity = 20, SupplierId = 1 },
                    new CarPart { Name = "Oil", Colour = null, Description = "To replace oil in cars", Price = 10, ReorderLevel = 10, ReorderQuantity = 50, SupplierId = 4 },
                    new CarPart { Name = "Exhaust", Colour = "Metallic", Description = "When an exhaust needs replacing", Price = 80, ReorderLevel = 5, ReorderQuantity = 10, SupplierId = 3 },
                    new CarPart { Name = "Windshield Wiper Blades", Colour = "Black", Description = "For replacing damaged wipers", Price = 30, ReorderLevel = 10, ReorderQuantity = 20, SupplierId = 6 },
                    new CarPart { Name = "Battery", Colour = "Black", Description = "To replace car batteries when required", Price = 60, ReorderLevel = 10, ReorderQuantity = 40, SupplierId = 2 },
                    new CarPart { Name = "Air Filter", Colour = "Red", Description = "Helps to filter the air intake", Price = 50, ReorderLevel = 15, ReorderQuantity = 30, SupplierId = 5 },
                    new CarPart { Name = "Hand Brake", Colour = "Black", Description = "Hand brake used for replacements.", Price = 70, ReorderLevel = 50, ReorderQuantity = 50, SupplierId = 5 },
                    new CarPart { Name = "Brake Pads", Colour = "Black", Description = "Brand new brake pads", Price = 70, ReorderLevel = 50, ReorderQuantity = 50, SupplierId = 5 },
                    new CarPart { Name = "Wheels", Colour = "Black", Description = "Quality wheels ideal for replacing.", Price = 70, ReorderLevel = 50, ReorderQuantity = 50, SupplierId = 2 },
                    new CarPart { Name = "Pine Scented Tree", Colour = "Green", Description = "The aroma of pine trees emanates from the dashboard", Price = 3, ReorderLevel = 10, ReorderQuantity = 30, SupplierId = 3 },
                    new CarPart { Name = "Ratchet Socket", Colour = "Metallic", Description = "For those DIY situations. . .", Price = 10, ReorderLevel = 5, ReorderQuantity = 30, SupplierId = 5 },
                    new CarPart { Name = "Alloys", Colour = "Silver", Description = "High quality alloys", Price = 40, ReorderLevel = 40, ReorderQuantity = 20, SupplierId = 1 },
                    new CarPart { Name = "Roof Racks", Colour = "Black/Silver", Description = "Roof rack to secure items on top of a car", Price = 60, ReorderLevel = 10, ReorderQuantity = 30, SupplierId = 3 },
                    new CarPart { Name = "Roof Box", Colour = "Black", Description = "Roof box to secure items on top of a car", Price = 70, ReorderLevel = 10, ReorderQuantity = 30, SupplierId = 1 },
                    new CarPart { Name = "Serpentine Belt", Colour = "Black", Description = "for use when the belt needs replacing", Price = 50, ReorderLevel = 25, ReorderQuantity = 25, SupplierId = 6 }
                );


            // Adding Jobs to Db Initializer // 
            context.Jobs.AddOrUpdate(
                p => p.JobId,
                   new Job { JobRequirements = "Belt Replacement", JobCost = 80, PartId = 15, JobStatus = 0 },
                   new Job { JobRequirements = "Windshield Wiper Replacement", JobCost = 30, PartId = 4, JobStatus = 0 },
                   new Job { JobRequirements = "Full MOT", JobCost = 150, PartId = 1, JobStatus = 0 },
                   new Job { JobRequirements = "Air Filter Replacement", JobCost = 65, PartId = 6, JobStatus = 0 },
                   new Job { JobRequirements = "Brake Pad Replacement", JobCost = 45, PartId = 7, JobStatus = 0 },
                   new Job { JobRequirements = "Hand Brake Replacement", JobCost = 70, PartId = 8, JobStatus = 0 },
                   new Job { JobRequirements = "Full Oil Change", JobCost = 25, PartId = 2, JobStatus = 0 },
                   new Job { JobRequirements = "Battery Fitting", JobCost = 20, PartId = 5, JobStatus = 0 },
                   new Job { JobRequirements = "Alloy Replacement", JobCost = 20, PartId = 7, JobStatus = 0 }
                );




            //context.Suppliers.AddOrUpdate(new Supplier { SupplierName = "Matheson", AddressLine1 = "2 Wallace Street", AddressLine2 = "Anderston", ContactName = "Sonny", EmailAddress = "mathesonsonny@gmail.com", Postcode = "G65 0NR", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" });
            //context.Suppliers.AddOrUpdate(new Supplier { SupplierName = "Matheson", AddressLine1 = "2 Wallace Street", AddressLine2 = "Anderston", ContactName = "Sonny", EmailAddress = "mathesonsonny@gmail.com", Postcode = "G65 0NR", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" });
            //context.Suppliers.AddOrUpdate(new Supplier { SupplierName = "Dhillons", AddressLine1 = "2 Almond Avenue", AddressLine2 = "Elmsley", ContactName = "Jack", EmailAddress = "jackalmonddhillons@gmail.com", Postcode = "G12 0ER", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" });
            //context.Suppliers.AddOrUpdate(new Supplier { SupplierName = "ACME", AddressLine1 = "ACME House", AddressLine2 = "15 Main Street", ContactName = "Heather", EmailAddress = "heatheracmehouse15@gmail.com", Postcode = "AC ME", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" });
            //context.Suppliers.AddOrUpdate(new Supplier { SupplierName = "Oil Wholesale", AddressLine1 = "221 Albert Crescent", AddressLine2 = "Cambridge", ContactName = "Vladimir", EmailAddress = "vladoilwholesalecam@gmail.com", Postcode = "CA1 0ZX", TelephoneNumber = "1233 7458 9456", Town = "Cambridge" });
            //context.Suppliers.AddOrUpdate(new Supplier { SupplierName = "Brand Mechanics", AddressLine1 = "84 Daisy Road", AddressLine2 = "Inverallan", ContactName = "Chad", EmailAddress = "ahmedsupplierm@gmail.com", Postcode = "G5 9JU", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" });
            //context.Suppliers.AddOrUpdate(new Supplier { SupplierName = "REueters", AddressLine1 = "25 Amolie Street", AddressLine2 = "Applesby", ContactName = "Arthur", EmailAddress = "ArtherApplesbyAmolie@gmail.com", Postcode = "G6 5JQ", TelephoneNumber = "1233 7458 9456", Town = "Applesby" });

            //// Adding Car Parts to Db Initializer //
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Wrench", Colour = "Red", Description = "A Red Wrench to get the job done !", Price = 10, ReorderLevel = 10, ReorderQuantity = 20, SupplierId = 1 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Oil", Colour = null, Description = "To replace oil in cars", Price = 10, ReorderLevel = 10, ReorderQuantity = 50, SupplierId = 4 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Exhaust", Colour = "Metallic", Description = "When an exhaust needs replacing", Price = 80, ReorderLevel = 5, ReorderQuantity = 10, SupplierId = 3 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Windshield Wiper Blades", Colour = "Black", Description = "For replacing damaged wipers", Price = 30, ReorderLevel = 10, ReorderQuantity = 20, SupplierId = 6 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Battery", Colour = "Black", Description = "To replace car batteries when required", Price = 60, ReorderLevel = 10, ReorderQuantity = 40, SupplierId = 2 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Air Filter", Colour = "Red", Description = "Helps to filter the air intake", Price = 50, ReorderLevel = 15, ReorderQuantity = 30, SupplierId = 5 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Brake Pads", Colour = "Black", Description = "Brand new brake pads", Price = 70, ReorderLevel = 50, ReorderQuantity = 50, SupplierId = 5 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Hand Brake", Colour = "Black", Description = "Hand brake used for replacements.", Price = 70, ReorderLevel = 50, ReorderQuantity = 50, SupplierId = 5 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Wheels", Colour = "Black", Description = "Quality wheels ideal for replacing.", Price = 70, ReorderLevel = 50, ReorderQuantity = 50, SupplierId = 2 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Pine Scented Tree", Colour = "Green", Description = "The aroma of pine trees emanates from the dashboard", Price = 3, ReorderLevel = 10, ReorderQuantity = 30, SupplierId = 3 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Ratchet Socket", Colour = "Metallic", Description = "For those DIY situations. . .", Price = 10, ReorderLevel = 5, ReorderQuantity = 30, SupplierId = 5 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Alloys", Colour = "Silver", Description = "High quality alloys", Price = 40, ReorderLevel = 40, ReorderQuantity = 20, SupplierId = 1 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Roof Racks", Colour = "Black/Silver", Description = "Roof rack to secure items on top of a car", Price = 60, ReorderLevel = 10, ReorderQuantity = 30, SupplierId = 3 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Roof Box", Colour = "Black", Description = "Roof box to secure items on top of a car", Price = 70, ReorderLevel = 10, ReorderQuantity = 30, SupplierId = 1 });
            ////context.CarParts.AddOrUpdate(new CarPart { Name = "Serpentine Belt", Colour = "Black", Description = "for use when the belt needs replacing", Price = 50, ReorderLevel = 25, ReorderQuantity = 25, SupplierId = 6 });

            //// Adding Jobs to Db Initializer //
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Belt Replacement", JobCost = 80, PartId = 15, JobStatus = 0, });
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Windshield Wiper Replacement", JobCost = 30, PartId = 4, JobStatus = 0, });
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Full MOT", JobCost = 150, PartId = 1, JobStatus = 0, });
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Air Filter Replacement", JobCost = 65, PartId = 6, JobStatus = 0, });
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Brake Pad Replacement", JobCost = 45, PartId = 7, JobStatus = 0, });
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Hand Brake Replacement", JobCost = 70, PartId = 8, JobStatus = 0, });
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Full Oil Change", JobCost = 25, PartId = 2, JobStatus = 0, });
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Battery Fitting", JobCost = 20, PartId = 5, JobStatus = 0, });
            //context.Jobs.AddOrUpdate(new Job { JobRequirements = "Alloy Replacement", JobCost = 20, PartId = 7, JobStatus = 0, });


        }
    }
}
