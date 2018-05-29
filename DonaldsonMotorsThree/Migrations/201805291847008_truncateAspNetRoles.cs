namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class truncateAspNetRoles : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM dbo.AspNetRoles");
            Sql("DELETE FROM dbo.AspNetUserRoles");
        }
        
        
        public override void Down()
        {
        }
    }
}
