namespace IBC.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FaceMask", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TKE", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.X1Blade", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.X1Blade", "Price");
            DropColumn("dbo.TKE", "Price");
            DropColumn("dbo.FaceMask", "Price");
        }
    }
}
