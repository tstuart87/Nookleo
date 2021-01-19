namespace Nookleo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Location", "Latitude", c => c.Double());
            AlterColumn("dbo.Location", "Longitude", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Location", "Longitude", c => c.Int());
            AlterColumn("dbo.Location", "Latitude", c => c.Int());
        }
    }
}
