namespace Wrox.ProCSharp.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 40),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Day = c.DateTime(storeType: "date"),
                        MenuCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuCards", t => t.MenuCardId, cascadeDelete: true)
                .Index(t => t.MenuCardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "MenuCardId", "dbo.MenuCards");
            DropIndex("dbo.Menus", new[] { "MenuCardId" });
            DropTable("dbo.Menus");
            DropTable("dbo.MenuCards");
        }
    }
}
