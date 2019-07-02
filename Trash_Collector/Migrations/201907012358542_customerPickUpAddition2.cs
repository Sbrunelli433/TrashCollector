namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerPickUpAddition2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "collection", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "extraCollection", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ConfirmPickup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "ConfirmExtraPickup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "ChargeToBill", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ChargeToBill");
            DropColumn("dbo.Employees", "ConfirmExtraPickup");
            DropColumn("dbo.Employees", "ConfirmPickup");
            DropColumn("dbo.Customers", "extraCollection");
            DropColumn("dbo.Customers", "collection");
        }
    }
}
