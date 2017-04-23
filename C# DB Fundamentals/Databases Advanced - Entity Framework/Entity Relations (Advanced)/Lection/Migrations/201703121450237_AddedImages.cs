namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChImgs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.Binary(),
                        ChirpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chirps", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Chirps", "AuthorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChImgs", "Id", "dbo.Chirps");
            DropIndex("dbo.ChImgs", new[] { "Id" });
            DropColumn("dbo.Chirps", "AuthorId");
            DropTable("dbo.ChImgs");
        }
    }
}
