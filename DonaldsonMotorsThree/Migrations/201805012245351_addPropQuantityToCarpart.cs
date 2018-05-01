namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPropQuantityToCarpart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarParts", "CurrentQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarParts", "CurrentQuantity");
        }
    }
}
