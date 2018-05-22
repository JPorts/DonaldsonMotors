namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookingModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.Bookings", new[] { "Job_JobId" });
            RenameColumn(table: "dbo.Bookings", name: "Job_JobId", newName: "JobId");
            AddColumn("dbo.Bookings", "startDate", c => c.DateTime());
            AddColumn("dbo.Bookings", "DateCompleted", c => c.DateTime());
            AddColumn("dbo.Bookings", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "JobId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "JobId");
            AddForeignKey("dbo.Bookings", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "JobId", "dbo.Jobs");
            DropIndex("dbo.Bookings", new[] { "JobId" });
            AlterColumn("dbo.Bookings", "JobId", c => c.Int());
            DropColumn("dbo.Bookings", "CustomerId");
            DropColumn("dbo.Bookings", "DateCompleted");
            DropColumn("dbo.Bookings", "startDate");
            RenameColumn(table: "dbo.Bookings", name: "JobId", newName: "Job_JobId");
            CreateIndex("dbo.Bookings", "Job_JobId");
            AddForeignKey("dbo.Bookings", "Job_JobId", "dbo.Jobs", "JobId");
        }
    }
}
