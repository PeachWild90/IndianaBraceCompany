namespace IBC.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FootEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.X1Blade", "Foot", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.X1Blade", "Foot", c => c.Boolean(nullable: false));
        }
    }
}
