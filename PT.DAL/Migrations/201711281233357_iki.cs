namespace PT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iki : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentID", "dbo.Department");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentID" });
            AlterColumn("dbo.AspNetUsers", "DepartmentID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "DepartmentID");
            AddForeignKey("dbo.AspNetUsers", "DepartmentID", "dbo.Department", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartmentID", "dbo.Department");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentID" });
            AlterColumn("dbo.AspNetUsers", "DepartmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "DepartmentID");
            AddForeignKey("dbo.AspNetUsers", "DepartmentID", "dbo.Department", "id", cascadeDelete: true);
        }
    }
}
