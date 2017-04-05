namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedChirpPK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Chirps", name: "Id", newName: "Key");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Chirps", name: "Key", newName: "Id");
        }
    }
}
