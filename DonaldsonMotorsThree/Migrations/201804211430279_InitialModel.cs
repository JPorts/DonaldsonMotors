namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarParts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(nullable: false),
                        Colour = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReorderLevel = c.Int(nullable: false),
                        ReorderQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        CompletedBy = c.String(),
                        DateCompleted = c.DateTime(nullable: false),
                        JobRequirements = c.String(nullable: false),
                        JobCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        JobStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(),
                        Town = c.String(),
                        Postcode = c.String(nullable: false),
                        TelephoneNumber = c.String(nullable: false),
                        ContactName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
            DropTable("dbo.Jobs");
            DropTable("dbo.CarParts");
        }
    }
}
