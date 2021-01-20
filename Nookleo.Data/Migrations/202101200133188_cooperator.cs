namespace Nookleo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cooperator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cooperator",
                c => new
                    {
                        CooperatorId = c.Int(nullable: false, identity: true),
                        StreetAddressOne = c.String(),
                        StreetAddressTwo = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        ZipCode = c.String(),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        ContactType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CooperatorId);
            
            AddColumn("dbo.Location", "CooperatorId", c => c.Int());
            CreateIndex("dbo.Location", "CooperatorId");
            AddForeignKey("dbo.Location", "CooperatorId", "dbo.Cooperator", "CooperatorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "CooperatorId", "dbo.Cooperator");
            DropIndex("dbo.Location", new[] { "CooperatorId" });
            DropColumn("dbo.Location", "CooperatorId");
            DropTable("dbo.Cooperator");
        }
    }
}
