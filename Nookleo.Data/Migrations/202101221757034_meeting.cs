namespace Nookleo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meeting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CornTask",
                c => new
                    {
                        CornTaskId = c.Int(nullable: false, identity: true),
                        GrowthStage = c.Int(nullable: false),
                        TaskOne = c.Int(nullable: false),
                        TaskTwo = c.Int(nullable: false),
                        TaskThree = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        TaskDate = c.DateTimeOffset(nullable: false, precision: 7),
                        TaskNote = c.String(),
                        PlotRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CornTaskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CornTask");
        }
    }
}
