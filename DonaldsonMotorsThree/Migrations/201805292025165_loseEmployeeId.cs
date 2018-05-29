namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loseEmployeeId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeId", c => c.Int(identity: true));
        }
    }
}
