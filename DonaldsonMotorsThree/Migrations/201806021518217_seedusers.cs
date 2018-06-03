namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        BasketItemId = c.Int(nullable: false, identity: true),
                        BasketId = c.Int(nullable: false),
                        CarPartId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketItemId)
                .ForeignKey("dbo.Baskets", t => t.BasketId, cascadeDelete: true)
                .Index(t => t.BasketId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        BasketId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BasketId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        PaidFor = c.Boolean(nullable: false),
                        DurationInDays = c.Int(),
                        Total = c.Double(),
                        StartDate = c.DateTime(),
                        DateCompleted = c.DateTime(),
                        CustomerId = c.String(maxLength: 128),
                        UserId = c.String(),
                        JobId = c.Int(nullable: false),
                        BookingStatus = c.String(),
                        Part_PartId = c.Int(),
                        Staff_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.CarParts", t => t.Part_PartId)
                .ForeignKey("dbo.AspNetUsers", t => t.Staff_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.JobId)
                .Index(t => t.Part_PartId)
                .Index(t => t.Staff_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        Town = c.String(),
                        Postcode = c.String(),
                        TelephoneNumber = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        VehicleId = c.Int(),
                        PaymentId = c.Int(),
                        Dob = c.DateTime(),
                        MobileNumber = c.String(),
                        MedContactDetails = c.String(),
                        EmergContactDetails = c.String(),
                        NiNumber = c.String(),
                        AreaOfExpertise = c.String(),
                        Rolename = c.String(),
                        Password = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        PartId = c.Int(nullable: false),
                        CompletedBy = c.String(),
                        DateCompleted = c.DateTime(),
                        JobRequirements = c.String(nullable: false),
                        JobCost = c.Double(nullable: false),
                        JobStatus = c.Int(nullable: false),
                        CarPartId = c.Int(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.CarParts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.PartId);
            
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
                        CurrentQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ReviewId = c.Int(nullable: false),
                        Header = c.String(),
                        Body = c.String(),
                        PostDate = c.DateTime(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.VehicleDetails",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        RegNumber = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        EngineSize = c.String(nullable: false),
                        Milage = c.Int(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleDetails", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "Staff_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "Part_PartId", "dbo.CarParts");
            DropForeignKey("dbo.Bookings", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "PartId", "dbo.CarParts");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.VehicleDetails", new[] { "CustomerId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropIndex("dbo.Jobs", new[] { "PartId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Bookings", new[] { "Staff_Id" });
            DropIndex("dbo.Bookings", new[] { "Part_PartId" });
            DropIndex("dbo.Bookings", new[] { "JobId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropTable("dbo.VehicleDetails");
            DropTable("dbo.Suppliers");
            DropTable("dbo.RoleViewModels");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reviews");
            DropTable("dbo.CarParts");
            DropTable("dbo.Jobs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Bookings");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
