namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createparts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Wrench', 'A Red Wrench to get the job done!', 'Red', 10, 40, 50, 21)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Oil', 'When oil needs replaced in your car', null, 5, 35, 15, 100)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Air Filters', 'To replace Air filters in the vehicle', 'Red', 20, 25, 30,20)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Windshield Wiper Blades', 'Able to be fitted to all vehicles', 'Black', 20, 20, 50,35)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Pine Scented Tree', 'To add a piney finish!', 'Green', 3, 20, 50,13)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Low Rider Wheels', 'For the adventurous customer', 'Black', 36, 40, 65,29)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Wheels', 'For use in replacing vehicles wheels', 'Black', 30, 40, 65,61)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Rear View Mirror', 'Replacing the rearview', 'Black', 10, 30, 40,32)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Break Pads', 'For replacing worn out brake pads', 'Black', 25, 10, 20,2)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Serpentine Belt', 'When a vehicle belt needs replaced', 'Black', 30, 10, 25,3)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Shock Absorbers', 'Absorbing that Shock', 'Metallic', 18.99, 10, 20,12)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Exhaust', 'For exhaust replacements', 'red', 55, 15, 30,45)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Springs', 'To enhance suspension in vehicles', 'Metallic', 19.99, 30, 50,90)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Load Bearings', 'For large Class D Vehicles', 'Metallic', 45, 10, 20,10)");
            Sql("INSERT INTO CarParts (SupplierId, Name, Description, Colour, Price, ReorderLevel, ReorderQuantity, CurrentQuantity) VALUES (1, 'Wheel Aligners', 'Used to re-align wheels', 'Blue', 139.99, 10, 15,12)");

            // INSERT SUPPLIERS INTO SUPPLIER TABLE // 
            Sql("INSERT INTO Suppliers (SupplierName, AddressLine1, AddressLine2, Town, Postcode, TelephoneNumber, ContactName, EmailAddress) VALUES ('ACME','1 ACME House','Coyoteville','Clydebank','G81 0NR','0141 4141 9441','Barry','BarryAcmeHouseSupplier@Gmail.com')");
            Sql("INSERT INTO Suppliers (SupplierName, AddressLine1, AddressLine2, Town, Postcode, TelephoneNumber, ContactName, EmailAddress) VALUES ('Oil Wholesale', '25 North Sea Avenue', 'Abes Point','Aberdeen', 'AB10 7JJ', '01416 922 0192', 'Clementine' ,'ClementineOilWholesaleSupply@gmail.com')");
            Sql("INSERT INTO Suppliers (SupplierName, AddressLine1, AddressLine2, Town, Postcode, TelephoneNumber, ContactName, EmailAddress) VALUES ('Wellards','64 Roman Crescent','Old Kilpatrick','Clydebank','G81 XXR','0141 4141 9441','Jordan','WellardsJordanSupplier@Gmail.com')");
            Sql("INSERT INTO Suppliers (SupplierName, AddressLine1, AddressLine2, Town, Postcode, TelephoneNumber, ContactName, EmailAddress) VALUES ('Carentus','400 Wharf Road','Canary Wharf','London','NW1 1CW','0800 6001 001','Mortimer','MortimerCarentusSupplier@Gmail.com')");
            Sql("INSERT INTO Suppliers (SupplierName, AddressLine1, AddressLine2, Town, Postcode, TelephoneNumber, ContactName, EmailAddress) VALUES ('A&B Company','CeeDee Industrial','Charlesly','Wolverhampton','WO12 0NR','0141 4141 9441','Cecilia','CeciliaABCompanySupplier@Gmail.com')");
            Sql("INSERT INTO Suppliers (SupplierName, AddressLine1, AddressLine2, Town, Postcode, TelephoneNumber, ContactName, EmailAddress) VALUES ('RRW Mechanics Wholesale','101 Mezzanine Square','Llanfair Pwllgwyngyll ','Anglesey','WA14 3FT','01634 776 704','Ioan','IoanRRWMechanicsSupplier@Gmail.com')");

            // INSERT JOBS INTO JOBYPES TABLE // 
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ('Air Filter Replacement', 35.50)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ( 'Belt Replacement', 40)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ('Windshield Wiper Replacement', 20)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ('Full Oil Replacement', 65)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ('Wheel Replacement', 60)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ('Low Rider Wheels Fitting', 95.99)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ('Full MOT Service', 100)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ('Brake Pad Fitting', 38.99)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ( 'Exhaust Replacement', 50)");
            Sql("INSERT INTO JobTypes (JobRequirements, JobCost) VALUES ( 'Wheel Alignment', 15)");

            AddColumn("dbo.AspNetUsers", "PaymentMethod", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PaymentMethod");
        }
    }
}
