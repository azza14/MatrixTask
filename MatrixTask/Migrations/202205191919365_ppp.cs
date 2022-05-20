namespace MatrixTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppp : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PropertyCategories", newName: "CategoryTags");
            RenameColumn(table: "dbo.CategoryTags", name: "Property_Id", newName: "PropertyId");
            RenameColumn(table: "dbo.CategoryTags", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.CategoryTags", name: "IX_Category_Id", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.CategoryTags", name: "IX_Property_Id", newName: "IX_PropertyId");
            DropPrimaryKey("dbo.CategoryTags");
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.PropertyId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PropertyId);
            
            AddPrimaryKey("dbo.CategoryTags", new[] { "CategoryId", "PropertyId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductTags", new[] { "PropertyId" });
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropPrimaryKey("dbo.CategoryTags");
            DropTable("dbo.ProductTags");
            AddPrimaryKey("dbo.CategoryTags", new[] { "Property_Id", "Category_Id" });
            RenameIndex(table: "dbo.CategoryTags", name: "IX_PropertyId", newName: "IX_Property_Id");
            RenameIndex(table: "dbo.CategoryTags", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.CategoryTags", name: "CategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.CategoryTags", name: "PropertyId", newName: "Property_Id");
            RenameTable(name: "dbo.CategoryTags", newName: "PropertyCategories");
        }
    }
}
