namespace MatrixTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittag : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.Properties", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Properties", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Property_Id" });
            DropIndex("dbo.Properties", new[] { "CategoryId" });
            DropIndex("dbo.Properties", new[] { "Category_Id" });
            CreateTable(
                "dbo.PropertyCategories",
                c => new
                    {
                        Property_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Property_Id, t.Category_Id })
                .ForeignKey("dbo.Properties", t => t.Property_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Property_Id)
                .Index(t => t.Category_Id);
            
            DropColumn("dbo.Categories", "Property_Id");
            DropColumn("dbo.Properties", "CategoryId");
            DropColumn("dbo.Properties", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Category_Id", c => c.Int());
            AddColumn("dbo.Properties", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "Property_Id", c => c.Int());
            DropForeignKey("dbo.PropertyCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.PropertyCategories", "Property_Id", "dbo.Properties");
            DropIndex("dbo.PropertyCategories", new[] { "Category_Id" });
            DropIndex("dbo.PropertyCategories", new[] { "Property_Id" });
            DropTable("dbo.PropertyCategories");
            CreateIndex("dbo.Properties", "Category_Id");
            CreateIndex("dbo.Properties", "CategoryId");
            CreateIndex("dbo.Categories", "Property_Id");
            AddForeignKey("dbo.Properties", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Properties", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "Property_Id", "dbo.Properties", "Id");
        }
    }
}
