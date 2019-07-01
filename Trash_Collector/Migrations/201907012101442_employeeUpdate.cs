namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "CustomerZipCodes", "dbo.Customers");
            DropIndex("dbo.Employees", new[] { "CustomerZipCodes" });
            DropColumn("dbo.Employees", "CustomerZipCodes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "CustomerZipCodes", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "CustomerZipCodes");
            AddForeignKey("dbo.Employees", "CustomerZipCodes", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
