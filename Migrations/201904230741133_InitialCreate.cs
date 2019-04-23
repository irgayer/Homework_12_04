namespace Homework_12_04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        PassportId = c.String(),
                        EntryTime = c.DateTime(nullable: false),
                        ExitTime = c.DateTime(nullable: true),
                        VisitPurpose = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visitors");
        }
    }
}
