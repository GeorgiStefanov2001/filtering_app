namespace PSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCarRating : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Rating", c => c.Double(nullable: false));
        }
    }
}
