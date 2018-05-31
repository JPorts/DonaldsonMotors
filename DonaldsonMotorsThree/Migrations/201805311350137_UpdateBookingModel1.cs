namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookingModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Part_PartId", c => c.Int());
            CreateIndex("dbo.Bookings", "Part_PartId");
            AddForeignKey("dbo.Bookings", "Part_PartId", "dbo.CarParts", "PartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Part_PartId", "dbo.CarParts");
            DropIndex("dbo.Bookings", new[] { "Part_PartId" });
            DropColumn("dbo.Bookings", "Part_PartId");
        }
    }
}
