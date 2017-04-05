namespace ProductsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dwada : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 15));
        }
    }
}
