namespace IBC.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumColor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FaceMask", "Color", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FaceMask", "Color", c => c.Boolean(nullable: false));
        }
    }
}
