namespace MatrixTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProduct1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Properties", "Product_Code", "dbo.Products");
            DropIndex("dbo.Properties", new[] { "Product_Code" });
            DropColumn("dbo.Properties", "Product_Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Product_Code", c => c.Int());
            CreateIndex("dbo.Properties", "Product_Code");
            AddForeignKey("dbo.Properties", "Product_Code", "dbo.Products", "Code");
        }
    }
}
