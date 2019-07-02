namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerBilling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Billing", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Billing");
        }
    }
}
