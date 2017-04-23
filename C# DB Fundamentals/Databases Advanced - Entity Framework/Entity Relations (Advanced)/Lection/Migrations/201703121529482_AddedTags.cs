namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagRef = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TagRef);
            
            CreateTable(
                "dbo.ChirpTags",
                c => new
                    {
                        TagRef = c.String(nullable: false, maxLength: 128),
                        ChirpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagRef, t.ChirpId })
                .ForeignKey("dbo.Tags", t => t.TagRef, cascadeDelete: true)
                .ForeignKey("dbo.Chirps", t => t.ChirpId, cascadeDelete: true)
                .Index(t => t.TagRef)
                .Index(t => t.ChirpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChirpTags", "ChirpId", "dbo.Chirps");
            DropForeignKey("dbo.ChirpTags", "TagRef", "dbo.Tags");
            DropIndex("dbo.ChirpTags", new[] { "ChirpId" });
            DropIndex("dbo.ChirpTags", new[] { "TagRef" });
            DropTable("dbo.ChirpTags");
            DropTable("dbo.Tags");
        }
    }
}
