namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDirector : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "Director_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Director_Id");
            AddForeignKey("dbo.Movies", "Director_Id", "dbo.Directors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Director_Id", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "Director_Id" });
            DropColumn("dbo.Movies", "Director_Id");
            DropTable("dbo.Directors");
        }
    }
}
