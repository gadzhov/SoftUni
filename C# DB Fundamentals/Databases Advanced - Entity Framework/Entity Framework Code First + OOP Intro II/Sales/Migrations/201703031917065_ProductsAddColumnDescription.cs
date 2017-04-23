namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ProductsAddColumnDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String(defaultValue: "No Description"));
        }

        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
        }
    }
}
