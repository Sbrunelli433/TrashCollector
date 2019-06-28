namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationId" });
            DropColumn("dbo.Employees", "ApplicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "ApplicationId");
            AddForeignKey("dbo.Employees", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
    }
}
