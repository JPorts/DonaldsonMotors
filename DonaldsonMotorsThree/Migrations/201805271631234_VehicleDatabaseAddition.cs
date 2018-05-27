namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleDatabaseAddition : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleDetails");
        }
    }
}
