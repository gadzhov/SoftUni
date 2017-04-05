namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDuration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Duration");
        }
    }
}
