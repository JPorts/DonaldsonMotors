namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "PartId", "dbo.CarParts");
            DropIndex("dbo.Jobs", new[] { "PartId" });
            AddColumn("dbo.CarParts", "Job_JobId", c => c.Int());
            CreateIndex("dbo.CarParts", "Job_JobId");
            AddForeignKey("dbo.CarParts", "Job_JobId", "dbo.Jobs", "JobId");
            DropColumn("dbo.Jobs", "PartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "PartId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CarParts", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.CarParts", new[] { "Job_JobId" });
            DropColumn("dbo.CarParts", "Job_JobId");
            CreateIndex("dbo.Jobs", "PartId");
            AddForeignKey("dbo.Jobs", "PartId", "dbo.CarParts", "PartId", cascadeDelete: true);
        }
    }
}
