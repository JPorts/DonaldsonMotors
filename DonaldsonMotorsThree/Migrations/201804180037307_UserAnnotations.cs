namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "TelephoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "TelephoneNumber", c => c.String());
        }
    }
}
