namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChangevehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Vehicle_VehicleId", c => c.Int());
            CreateIndex("dbo.Bookings", "Vehicle_VehicleId");
            AddForeignKey("dbo.Bookings", "Vehicle_VehicleId", "dbo.VehicleDetails", "VehicleId");
            DropColumn("dbo.Bookings", "VehicleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "VehicleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bookings", "Vehicle_VehicleId", "dbo.VehicleDetails");
            DropIndex("dbo.Bookings", new[] { "Vehicle_VehicleId" });
            DropColumn("dbo.Bookings", "Vehicle_VehicleId");
        }
    }
}
