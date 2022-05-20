namespace MatrixTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategories", "Product_Code", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.ProductCategories", new[] { "Product_Code" });
            DropIndex("dbo.ProductCategories", new[] { "Category_Id" });
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropTable("dbo.ProductCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_Code = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Code, t.Category_Id });
            
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropColumn("dbo.Products", "CategoryId");
            CreateIndex("dbo.ProductCategories", "Category_Id");
            CreateIndex("dbo.ProductCategories", "Product_Code");
            AddForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategories", "Product_Code", "dbo.Products", "Code", cascadeDelete: true);
        }
    }
}
