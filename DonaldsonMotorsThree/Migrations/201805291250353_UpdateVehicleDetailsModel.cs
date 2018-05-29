namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVehicleDetailsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleDetails", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleDetails", "BookingId", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleDetails", "Customer_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.VehicleDetails", "Customer_Id");
            AddForeignKey("dbo.VehicleDetails", "Customer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleDetails", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.VehicleDetails", new[] { "Customer_Id" });
            DropColumn("dbo.VehicleDetails", "Customer_Id");
            DropColumn("dbo.VehicleDetails", "BookingId");
            DropColumn("dbo.VehicleDetails", "CustomerId");
        }
    }
}
