namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepropertyagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookModels", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookModels", "Price", c => c.Double());
        }
    }
}
