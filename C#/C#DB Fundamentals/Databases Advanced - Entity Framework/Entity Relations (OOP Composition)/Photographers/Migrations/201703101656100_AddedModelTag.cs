namespace Photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagLabel = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TagLabel, unique: true);
            
            CreateTable(
                "dbo.TagAlbums",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Album_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.TagAlbums", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagAlbums", new[] { "Album_Id" });
            DropIndex("dbo.TagAlbums", new[] { "Tag_Id" });
            DropIndex("dbo.Tags", new[] { "TagLabel" });
            DropTable("dbo.TagAlbums");
            DropTable("dbo.Tags");
        }
    }
}
