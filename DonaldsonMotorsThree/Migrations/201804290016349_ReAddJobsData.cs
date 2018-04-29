namespace DonaldsonMotorsThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddJobsData : DbMigration
    {
        public override void Up()
        {
            // INSERT JOBS INTO JOBS TABLE // 
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (3, 0, 'Air Filter Replacement', 35, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (10, 0, 'Belt Replacement', 40, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (4, 0, 'Windshield Wiper Replacement', 20, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (2, 0, 'Full Oil Replacement', 65, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (7, 0, 'Wheel Replacement', 60, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (6, 0, 'Low Rider Wheels Fitting', 95.99, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (1, 0, 'Full MOT Service', 100, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (9, 0, 'Brake Pad Fitting', 38.99, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (12, 0, 'Exhaust Replacement', 50, 0)");
            Sql("INSERT INTO Jobs (PartId, CustomerId, JobRequirements, JobCost, JobStatus) VALUES (15, 0, 'Wheel Alignment', 15, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
