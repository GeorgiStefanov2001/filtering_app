namespace PSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieBudget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Budget", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Budget");
        }
    }
}
