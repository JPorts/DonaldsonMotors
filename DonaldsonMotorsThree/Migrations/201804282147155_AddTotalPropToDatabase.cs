namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalPropToDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Total", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Total");
        }
    }
}
