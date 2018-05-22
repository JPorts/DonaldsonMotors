namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPostDateForReviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "PostDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "PostDate");
        }
    }
}
