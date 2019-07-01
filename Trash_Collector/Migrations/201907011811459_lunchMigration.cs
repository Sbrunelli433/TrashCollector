namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lunchMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EmailAddress", c => c.String());
            AddColumn("dbo.Customers", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Username");
            DropColumn("dbo.Customers", "EmailAddress");
        }
    }
}
