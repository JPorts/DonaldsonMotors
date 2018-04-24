namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBookingModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Job_JobId", c => c.Int());
            CreateIndex("dbo.Bookings", "Job_JobId");
            AddForeignKey("dbo.Bookings", "Job_JobId", "dbo.Jobs", "JobId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.Bookings", new[] { "Job_JobId" });
            DropColumn("dbo.Bookings", "Job_JobId");
        }
    }
}
