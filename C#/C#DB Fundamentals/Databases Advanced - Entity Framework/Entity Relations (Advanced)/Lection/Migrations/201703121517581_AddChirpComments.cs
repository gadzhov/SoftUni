namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChirpComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ChirpRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chirps", t => t.ChirpRefId, cascadeDelete: true)
                .Index(t => t.ChirpRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ChirpRefId", "dbo.Chirps");
            DropIndex("dbo.Comments", new[] { "ChirpRefId" });
            DropTable("dbo.Comments");
        }
    }
}
