namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetToSharedKey : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ChImgs", "ChirpId");
            RenameColumn(table: "dbo.ChImgs", name: "Id", newName: "ChirpId");
            RenameIndex(table: "dbo.ChImgs", name: "IX_Id", newName: "IX_ChirpId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ChImgs", name: "IX_ChirpId", newName: "IX_Id");
            RenameColumn(table: "dbo.ChImgs", name: "ChirpId", newName: "Id");
            AddColumn("dbo.ChImgs", "ChirpId", c => c.Int(nullable: false));
        }
    }
}
