namespace IBC.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMasterCartDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterCart",
                c => new
                    {
                        MasterCartId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        X1BladeId = c.Int(nullable: false),
                        Injury = c.Int(nullable: false),
                        FootSize = c.String(),
                        Foot = c.Int(nullable: false),
                        X1Quantity = c.Int(nullable: false),
                        X1Price = c.Int(nullable: false),
                        TKEId = c.Int(nullable: false),
                        TKEQuantity = c.Int(nullable: false),
                        TKEPrice = c.Int(nullable: false),
                        Reason = c.String(),
                        FaceMaskId = c.Int(nullable: false),
                        FMQuantity = c.Int(nullable: false),
                        FMPrice = c.Int(nullable: false),
                        Style = c.Int(nullable: false),
                        Personalization = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Height = c.String(),
                        Weight = c.String(),
                        Sport = c.String(),
                    })
                .PrimaryKey(t => t.MasterCartId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MasterCart");
        }
    }
}
