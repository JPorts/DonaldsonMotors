namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBookingTotalToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "JobCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "JobCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
