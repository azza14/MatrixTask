namespace MatrixTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_Code = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Code, t.Category_Id })
                .ForeignKey("dbo.Products", t => t.Product_Code, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Product_Code)
                .Index(t => t.Category_Id);
            
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_Code", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Product_Code" });
            DropTable("dbo.ProductCategories");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
