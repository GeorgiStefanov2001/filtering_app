namespace PSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMovieBudget : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Budget");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Budget", c => c.Double(nullable: false));
        }
    }
}
