namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tidybooking : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Part_PartId", "dbo.CarParts");
            DropIndex("dbo.Bookings", new[] { "Part_PartId" });
            DropColumn("dbo.Bookings", "UserId");
            DropColumn("dbo.Bookings", "JobId");
            DropColumn("dbo.Bookings", "Part_PartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Part_PartId", c => c.Int());
            AddColumn("dbo.Bookings", "JobId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "UserId", c => c.String());
            CreateIndex("dbo.Bookings", "Part_PartId");
            AddForeignKey("dbo.Bookings", "Part_PartId", "dbo.CarParts", "PartId");
        }
    }
}
