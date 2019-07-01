namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerMigrationConsolidation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "EmailAddress");
            DropColumn("dbo.Customers", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Username", c => c.String(maxLength: 50));
            AddColumn("dbo.Customers", "EmailAddress", c => c.String(maxLength: 50));
        }
    }
}
