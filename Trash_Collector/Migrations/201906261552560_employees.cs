namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "EmailAddress", c => c.String());
            AddColumn("dbo.Employees", "Username", c => c.String());
            AddColumn("dbo.Employees", "Address", c => c.String());
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "State", c => c.String());
            AddColumn("dbo.Employees", "Zipcode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Zipcode");
            DropColumn("dbo.Employees", "State");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "Username");
            DropColumn("dbo.Employees", "EmailAddress");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "FirstName");
        }
    }
}
