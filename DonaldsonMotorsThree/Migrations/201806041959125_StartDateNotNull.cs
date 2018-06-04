namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartDateNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Bookings", "StartDate", c => c.DateTime());
        }
    }
}
