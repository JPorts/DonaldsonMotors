namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedvehcileidtobooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "VehicleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "VehicleId");
        }
    }
}
