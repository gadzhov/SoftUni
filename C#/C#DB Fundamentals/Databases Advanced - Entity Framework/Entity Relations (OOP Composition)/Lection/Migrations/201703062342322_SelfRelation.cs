namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelfRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Manager_Id", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Manager_Id" });
            DropTable("dbo.Employees");
        }
    }
}
