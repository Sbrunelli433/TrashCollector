namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomersTableNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickUpDay", c => c.DateTime());
            AlterColumn("dbo.Customers", "ExtraPickUpDay", c => c.DateTime());
            AlterColumn("dbo.Customers", "ServiceStartDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "ServiceEndDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "SuspendServiceStartDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "SuspendServiceEndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "SuspendServiceEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "SuspendServiceStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "ServiceEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "ServiceStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "ExtraPickUpDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "PickUpDay", c => c.DateTime(nullable: false));
        }
    }
}
