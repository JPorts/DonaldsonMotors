namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedvehicletoexcludebookingid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VehicleDetails", "BookingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleDetails", "BookingId", c => c.Int(nullable: false));
        }
    }
}
