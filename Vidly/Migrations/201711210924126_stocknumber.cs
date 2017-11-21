namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stocknumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StockAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StockAmount");
        }
    }
}
