namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieAmountToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
        }
    }
}
