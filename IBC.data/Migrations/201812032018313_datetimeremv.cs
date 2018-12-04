namespace IBC.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeremv : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FaceMask", "CreatedUtc");
            DropColumn("dbo.FaceMask", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FaceMask", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.FaceMask", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
