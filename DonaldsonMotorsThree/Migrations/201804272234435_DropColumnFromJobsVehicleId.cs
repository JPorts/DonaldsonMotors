namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumnFromJobsVehicleId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "CustomerId", c => c.Int());
            AlterColumn("dbo.Jobs", "DateCompleted", c => c.DateTime());
            DropColumn("dbo.Jobs", "VehicleId");
            Sql("TRUNCATE TABLE Jobs");
            Sql("TRUNCATE TABLE Suppliers");
            Sql("TRUNCATE TABLE CarParts");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "VehicleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "DateCompleted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
