namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaveMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Address", c => c.String());
            AlterColumn("dbo.Books", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "FinalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Adress", c => c.String());
            AlterColumn("dbo.Orders", "FinalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Books", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "Address");
        }
    }
}
