namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Author = c.String(),
                        Year = c.DateTime(nullable: false),
                        Pages = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Publisher = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdateBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        DeliveryService = c.String(),
                        Adress = c.String(),
                        TimeOfOrder = c.DateTime(nullable: false),
                        FinalPrice = c.Double(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdateBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Byte(nullable: false),
                        Money = c.Double(nullable: false),
                        TelephoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        Sex = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdateBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Orders", "BookId", "dbo.Books");
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropIndex("dbo.Orders", new[] { "BookId" });
            DropTable("dbo.Buyers");
            DropTable("dbo.Orders");
            DropTable("dbo.Books");
        }
    }
}
