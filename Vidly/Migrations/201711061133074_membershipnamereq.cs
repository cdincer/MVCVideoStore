namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membershipnamereq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));

        }

        public override void Down()
        {
           DropColumn("dbo.MembershipTypes", "Name");

        }
    }
}
