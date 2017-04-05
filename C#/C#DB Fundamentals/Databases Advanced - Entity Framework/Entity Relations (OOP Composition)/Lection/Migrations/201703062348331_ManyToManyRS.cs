namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyRS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.Employee_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmployees", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.ProjectEmployees", new[] { "Project_Id" });
            DropTable("dbo.ProjectEmployees");
            DropTable("dbo.Projects");
        }
    }
}
