namespace Photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhotographerAlbums", "Role", builder => builder.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhotographerAlbums", "Role");
        }
    }
}
