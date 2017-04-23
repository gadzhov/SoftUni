namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetColumnLenghts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Alias", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Chirps", "Content", c => c.String(maxLength: 130));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chirps", "Content", c => c.String());
            AlterColumn("dbo.People", "Alias", c => c.String());
        }
    }
}
