namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBookingDurationPropTonullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "DurationInDays", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "DurationInDays", c => c.Int(nullable: false));
        }
    }
}
