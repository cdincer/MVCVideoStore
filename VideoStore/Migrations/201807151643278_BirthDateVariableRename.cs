namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthDateVariableRename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            DropColumn("dbo.Customers", "BirthDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirthDay", c => c.DateTime());
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
