namespace PSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        VehicleType = c.String(),
                        Year = c.Int(nullable: false),
                        EngineLitres = c.Double(nullable: false),
                        NumberOfDoors = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
