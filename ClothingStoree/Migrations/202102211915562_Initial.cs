namespace ClothingStoree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoughtJewels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        JewelId = c.Int(nullable: false),
                        Customers_ID = c.Int(),
                        Jewels_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customers_ID)
                .ForeignKey("dbo.Jewels", t => t.Jewels_ID)
                .Index(t => t.Customers_ID)
                .Index(t => t.Jewels_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Clothes_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clothes", t => t.Clothes_ID, cascadeDelete: true)
                .Index(t => t.Clothes_ID);
            
            CreateTable(
                "dbo.Clothes",
                c => new
                    {
                        Clothes_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Color = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Clothes_ID);
            
            CreateTable(
                "dbo.Jewels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JewelsCustomers",
                c => new
                    {
                        Jewels_ID = c.Int(nullable: false),
                        Customers_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Jewels_ID, t.Customers_ID })
                .ForeignKey("dbo.Jewels", t => t.Jewels_ID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customers_ID, cascadeDelete: true)
                .Index(t => t.Jewels_ID)
                .Index(t => t.Customers_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoughtJewels", "Jewels_ID", "dbo.Jewels");
            DropForeignKey("dbo.BoughtJewels", "Customers_ID", "dbo.Customers");
            DropForeignKey("dbo.JewelsCustomers", "Customers_ID", "dbo.Customers");
            DropForeignKey("dbo.JewelsCustomers", "Jewels_ID", "dbo.Jewels");
            DropForeignKey("dbo.Customers", "Clothes_ID", "dbo.Clothes");
            DropIndex("dbo.JewelsCustomers", new[] { "Customers_ID" });
            DropIndex("dbo.JewelsCustomers", new[] { "Jewels_ID" });
            DropIndex("dbo.Customers", new[] { "Clothes_ID" });
            DropIndex("dbo.BoughtJewels", new[] { "Jewels_ID" });
            DropIndex("dbo.BoughtJewels", new[] { "Customers_ID" });
            DropTable("dbo.JewelsCustomers");
            DropTable("dbo.Jewels");
            DropTable("dbo.Clothes");
            DropTable("dbo.Customers");
            DropTable("dbo.BoughtJewels");
        }
    }
}
