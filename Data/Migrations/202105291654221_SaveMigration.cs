namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaveMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "PhoneNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Buyers", "TelephoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buyers", "TelephoneNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Buyers", "PhoneNumber");
        }
    }
}
