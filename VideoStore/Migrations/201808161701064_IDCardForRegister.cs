namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDCardForRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IDNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IDNumber");
        }
    }
}
