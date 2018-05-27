namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIncrementKeyToStaff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "EmployeeId", c => c.Int(identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "EmployeeId", c => c.Int());
        }
    }
}
