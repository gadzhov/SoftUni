namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResolvedMultipleRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "FK_dbo.People_dbo.Towns_PlaceOfBirth_Id");
            DropForeignKey("dbo.People", "FK_dbo.People_dbo.Towns_CurrentResidence_Id");
            DropIndex("dbo.People", new []{ "PlaceOfBirth_Id" });
            DropIndex("dbo.People", new []{ "CurrentResidence_Id" });

            DropIndex("dbo.People", new[] { "Town_Id" });
            DropIndex("dbo.People", new[] { "Town_Id1" });
            DropColumn("dbo.People", "PlaceOfBirth_Id");
            DropColumn("dbo.People", "CurrentResidence_Id");
            RenameColumn(table: "dbo.People", name: "Town_Id", newName: "PlaceOfBirth_Id");
            RenameColumn(table: "dbo.People", name: "Town_Id1", newName: "CurrentResidence_Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.People", name: "CurrentResidence_Id", newName: "Town_Id1");
            RenameColumn(table: "dbo.People", name: "PlaceOfBirth_Id", newName: "Town_Id");
            AddColumn("dbo.People", "CurrentResidence_Id", c => c.Int());
            AddColumn("dbo.People", "PlaceOfBirth_Id", c => c.Int());
            CreateIndex("dbo.People", "Town_Id1");
            CreateIndex("dbo.People", "Town_Id");
        }
    }
}
