namespace Nookleo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        ContactType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            AddColumn("dbo.Location", "TestingEmployeeId", c => c.Int());
            AddColumn("dbo.Location", "ProductDevelopmentEmployeeId", c => c.Int());
            AddColumn("dbo.Location", "BreedingEmployeeId", c => c.Int());
            CreateIndex("dbo.Location", "TestingEmployeeId");
            CreateIndex("dbo.Location", "ProductDevelopmentEmployeeId");
            CreateIndex("dbo.Location", "BreedingEmployeeId");
            AddForeignKey("dbo.Location", "BreedingEmployeeId", "dbo.Employee", "EmployeeId");
            AddForeignKey("dbo.Location", "ProductDevelopmentEmployeeId", "dbo.Employee", "EmployeeId");
            AddForeignKey("dbo.Location", "TestingEmployeeId", "dbo.Employee", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "TestingEmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Location", "ProductDevelopmentEmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Location", "BreedingEmployeeId", "dbo.Employee");
            DropIndex("dbo.Location", new[] { "BreedingEmployeeId" });
            DropIndex("dbo.Location", new[] { "ProductDevelopmentEmployeeId" });
            DropIndex("dbo.Location", new[] { "TestingEmployeeId" });
            DropColumn("dbo.Location", "BreedingEmployeeId");
            DropColumn("dbo.Location", "ProductDevelopmentEmployeeId");
            DropColumn("dbo.Location", "TestingEmployeeId");
            DropTable("dbo.Employee");
        }
    }
}
