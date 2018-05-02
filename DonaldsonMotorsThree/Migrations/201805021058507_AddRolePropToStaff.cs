namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolePropToStaff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Rolename", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Rolename");
        }
    }
}
