namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Billing", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "ExtraPickUpDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "ServiceStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "ServiceEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "SuspendServiceStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "SuspendServiceEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "PickUpDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickUpDay", c => c.String());
            DropColumn("dbo.Customers", "SuspendServiceEndDate");
            DropColumn("dbo.Customers", "SuspendServiceStartDate");
            DropColumn("dbo.Customers", "ServiceEndDate");
            DropColumn("dbo.Customers", "ServiceStartDate");
            DropColumn("dbo.Customers", "ExtraPickUpDay");
            DropColumn("dbo.Customers", "Billing");
        }
    }
}
