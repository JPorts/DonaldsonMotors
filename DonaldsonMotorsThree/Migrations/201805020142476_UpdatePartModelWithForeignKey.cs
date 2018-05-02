namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePartModelWithForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "CarPartId", c => c.Int());
            CreateIndex("dbo.Jobs", "PartId");
            AddForeignKey("dbo.Jobs", "PartId", "dbo.CarParts", "PartId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "PartId", "dbo.CarParts");
            DropIndex("dbo.Jobs", new[] { "PartId" });
            DropColumn("dbo.Jobs", "CarPartId");
        }
    }
}
