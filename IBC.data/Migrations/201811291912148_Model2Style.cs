namespace IBC.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model2Style : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FaceMask", "Style", c => c.Int(nullable: false));
            DropColumn("dbo.FaceMask", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FaceMask", "Model", c => c.Int(nullable: false));
            DropColumn("dbo.FaceMask", "Style");
        }
    }
}
