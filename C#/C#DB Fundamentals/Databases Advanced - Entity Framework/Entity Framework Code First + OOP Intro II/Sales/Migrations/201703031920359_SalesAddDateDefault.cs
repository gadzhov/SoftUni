namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesAddDateDefault : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false, defaultValueSql:"GETDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Date");
        }
    }
}
