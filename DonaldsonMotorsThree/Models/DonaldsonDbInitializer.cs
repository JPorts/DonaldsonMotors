using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DonaldsonMotorsThree.Models
{
    public class DonaldsonDbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<DonaldsonMotorsDataContext>
    {
        protected override void Seed(DonaldsonMotorsDataContext context)
        {
            // Adding Suppliers Context To Db Initializer // 
            context.Suppliers.Add(new Supplier {SupplierName = "Matheson", AddressLine1 = "2 Wallace Street", AddressLine2 = "Anderston", ContactName = "Sonny", EmailAddress = "mathesonsonny@gmail.com", Postcode = "G65 0NR", TelephoneNumber = "1233 7458 9456", Town = "Glasgow"});
            context.Suppliers.Add(new Supplier { SupplierName = "Dhillons", AddressLine1 = "2 Almond Avenue", AddressLine2 = "Elmsley", ContactName = "Jack", EmailAddress = "jackalmonddhillons@gmail.com", Postcode = "G12 0ER", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" });
            context.Suppliers.Add(new Supplier { SupplierName = "ACME", AddressLine1 = "ACME House", AddressLine2 = "15 Main Street", ContactName = "Heather", EmailAddress = "heatheracmehouse15@gmail.com", Postcode = "AC ME", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" });
            context.Suppliers.Add(new Supplier { SupplierName = "Oil Wholesale", AddressLine1 = "221 Albert Crescent", AddressLine2 = "Cambridge", ContactName = "Vladimir", EmailAddress = "vladoilwholesalecam@gmail.com", Postcode = "CA1 0ZX", TelephoneNumber = "1233 7458 9456", Town = "Cambridge" });
            context.Suppliers.Add(new Supplier { SupplierName = "Brand Mechanics", AddressLine1 = "84 Daisy Road", AddressLine2 = "Inverallan", ContactName = "Chad", EmailAddress = "ahmedsupplierm@gmail.com", Postcode = "G5 9JU", TelephoneNumber = "1233 7458 9456", Town = "Glasgow" });
            context.Suppliers.Add(new Supplier { SupplierName = "REueters", AddressLine1 = "25 Amolie Street", AddressLine2 = "Applesby", ContactName = "Arthur", EmailAddress = "ArtherApplesbyAmolie@gmail.com", Postcode = "G6 5JQ", TelephoneNumber = "1233 7458 9456", Town = "Applesby" });
            // Adding Car Parts to Db Initializer //
            context.CarParts.Add(new CarPart { Name = "Wrench", Colour = "Red", Description = "A Red Wrench to get the job done !", Price = 10, ReorderLevel = 10, ReorderQuantity = 20, SupplierId = 1});
            context.CarParts.Add(new CarPart { Name = "Oil", Colour = null, Description = "To replace oil in cars", Price = 10, ReorderLevel = 10, ReorderQuantity = 50, SupplierId = 4 });
            context.CarParts.Add(new CarPart { Name = "Exhaust", Colour = "Metallic", Description = "When an exhaust needs replacing", Price = 80, ReorderLevel = 5, ReorderQuantity = 10, SupplierId = 3 });
            context.CarParts.Add(new CarPart { Name = "Windshield Wiper Blades", Colour = "Black", Description = "For replacing damaged wipers", Price = 30, ReorderLevel = 10, ReorderQuantity = 20, SupplierId = 6 });
            context.CarParts.Add(new CarPart { Name = "Battery", Colour = "Black", Description = "To replace car batteries when required", Price = 60, ReorderLevel = 10, ReorderQuantity = 40, SupplierId = 2 });
            context.CarParts.Add(new CarPart { Name = "Tires", Colour = "Black", Description = "Quality tires ideal for replacing.", Price = 70, ReorderLevel = 50, ReorderQuantity = 50, SupplierId = 5 });



        }

    }
}