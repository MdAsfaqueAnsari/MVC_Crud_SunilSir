namespace MVC_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.category_Id)
                .Index(t => t.category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
