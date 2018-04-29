namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllFromJobs : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Jobs WHERE JobId > 3010");
        }
        
        public override void Down()
        {
        }
    }
}
