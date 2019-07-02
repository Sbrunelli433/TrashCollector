namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigratonemployeeModelReduction : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "State", c => c.String());
            AddColumn("dbo.Employees", "City", c => c.String());
            AddColumn("dbo.Employees", "Address", c => c.String());
        }
    }
}
