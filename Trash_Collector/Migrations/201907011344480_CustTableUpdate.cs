namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Billing");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Billing", c => c.Double(nullable: false));
        }
    }
}
