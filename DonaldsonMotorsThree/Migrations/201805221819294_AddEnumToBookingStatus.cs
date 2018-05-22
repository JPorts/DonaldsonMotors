namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnumToBookingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "BookingStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "Total", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Total", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Bookings", "BookingStatus");
        }
    }
}
