namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeprop : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookModels", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookModels", "Price", c => c.Double(nullable: false));
        }
    }
}
