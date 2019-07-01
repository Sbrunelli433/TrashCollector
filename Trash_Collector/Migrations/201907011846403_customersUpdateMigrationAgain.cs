namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customersUpdateMigrationAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "EmailAddress");
            DropColumn("dbo.Customers", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Username", c => c.String());
            AddColumn("dbo.Customers", "EmailAddress", c => c.String());
        }
    }
}
