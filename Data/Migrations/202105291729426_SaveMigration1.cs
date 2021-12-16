namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaveMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyers", "Money", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buyers", "Money", c => c.Double(nullable: false));
        }
    }
}
