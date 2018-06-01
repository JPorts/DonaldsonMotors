namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookingModeltoFitForPurpose : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "UserId", c => c.String());
            AddColumn("dbo.Bookings", "Staff_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bookings", "Staff_Id");
            AddForeignKey("dbo.Bookings", "Staff_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Staff_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "Staff_Id" });
            DropColumn("dbo.Bookings", "Staff_Id");
            DropColumn("dbo.Bookings", "UserId");
        }
    }
}
