namespace PhotoShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsLogedInUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsLoged", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsLoged");
        }
    }
}
