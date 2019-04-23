namespace Homework_12_04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visitors", "ExitTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visitors", "ExitTime", c => c.DateTime(nullable: false));
        }
    }
}
