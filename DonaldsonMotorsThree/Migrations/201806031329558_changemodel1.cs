namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "JobId", "dbo.Jobs");
            DropIndex("dbo.Bookings", new[] { "JobId" });
            AddColumn("dbo.Jobs", "JobTypeId", c => c.Int());
            AddColumn("dbo.Jobs", "StartDate", c => c.DateTime());
            AddColumn("dbo.Jobs", "Booking_BookingId", c => c.Int());
            AddColumn("dbo.CarParts", "JobTypes_Id", c => c.Int());
            AlterColumn("dbo.Jobs", "CustomerId", c => c.String());
            AlterColumn("dbo.Jobs", "JobStatus", c => c.String(nullable: false));
            AlterColumn("dbo.CarParts", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Jobs", "Booking_BookingId");
            CreateIndex("dbo.CarParts", "JobTypes_Id");
            AddForeignKey("dbo.Jobs", "Booking_BookingId", "dbo.Bookings", "BookingId");
            AddForeignKey("dbo.CarParts", "JobTypes_Id", "dbo.JobTypes", "Id");
            DropColumn("dbo.Jobs", "CarPartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "CarPartId", c => c.Int());
            DropForeignKey("dbo.CarParts", "JobTypes_Id", "dbo.JobTypes");
            DropForeignKey("dbo.Jobs", "Booking_BookingId", "dbo.Bookings");
            DropIndex("dbo.CarParts", new[] { "JobTypes_Id" });
            DropIndex("dbo.Jobs", new[] { "Booking_BookingId" });
            AlterColumn("dbo.CarParts", "Name", c => c.String());
            AlterColumn("dbo.Jobs", "JobStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "CustomerId", c => c.Int());
            DropColumn("dbo.CarParts", "JobTypes_Id");
            DropColumn("dbo.Jobs", "Booking_BookingId");
            DropColumn("dbo.Jobs", "StartDate");
            DropColumn("dbo.Jobs", "JobTypeId");
            CreateIndex("dbo.Bookings", "JobId");
            AddForeignKey("dbo.Bookings", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
        }
    }
}
