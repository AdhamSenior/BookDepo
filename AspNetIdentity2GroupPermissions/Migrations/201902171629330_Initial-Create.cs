namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        CoverImagePath = c.String(),
                        Author = c.String(nullable: false),
                        Discription = c.String(nullable: false),
                        Condition = c.String(),
                        PublishYear = c.String(),
                        status = c.Boolean(),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookModels");
        }
    }
}
