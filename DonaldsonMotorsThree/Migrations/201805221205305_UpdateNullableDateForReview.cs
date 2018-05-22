namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNullableDateForReview : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "PostDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "PostDate", c => c.DateTime(nullable: false));
        }
    }
}
