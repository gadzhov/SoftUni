namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedUserPK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chirps", "Author_Id", "dbo.People");
            RenameColumn(table: "dbo.Chirps", name: "Author_Id", newName: "Author_Key");
            RenameIndex(table: "dbo.Chirps", name: "IX_Author_Id", newName: "IX_Author_Key");
            DropPrimaryKey("dbo.People");
            DropColumn("dbo.People", "Id");
            AddColumn("dbo.People", "Key", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "Key");
            AddForeignKey("dbo.Chirps", "Author_Key", "dbo.People", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Chirps", "Author_Key", "dbo.People");
            DropPrimaryKey("dbo.People");
            DropColumn("dbo.People", "Key");
            AddPrimaryKey("dbo.People", "Id");
            RenameIndex(table: "dbo.Chirps", name: "IX_Author_Key", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Chirps", name: "Author_Key", newName: "Author_Id");
            AddForeignKey("dbo.Chirps", "Author_Id", "dbo.People", "Id");
        }
    }
}
