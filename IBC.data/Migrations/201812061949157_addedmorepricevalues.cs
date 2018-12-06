namespace IBC.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmorepricevalues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FaceMask", "PriceValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TKE", "PriceValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.X1Blade", "PriceValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.FaceMask", "Price");
            DropColumn("dbo.TKE", "Price");
            DropColumn("dbo.X1Blade", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.X1Blade", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TKE", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FaceMask", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.X1Blade", "PriceValue");
            DropColumn("dbo.TKE", "PriceValue");
            DropColumn("dbo.FaceMask", "PriceValue");
        }
    }
}
