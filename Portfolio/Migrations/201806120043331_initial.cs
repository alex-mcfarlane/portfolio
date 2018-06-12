namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Body = c.String(),
                        ExternalLink = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        Project_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ID, t.Category_ID })
                .ForeignKey("dbo.Projects", t => t.Project_ID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Project_ID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectCategories", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.ProjectCategories", "Project_ID", "dbo.Projects");
            DropIndex("dbo.ProjectCategories", new[] { "Category_ID" });
            DropIndex("dbo.ProjectCategories", new[] { "Project_ID" });
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.Projects");
            DropTable("dbo.Categories");
        }
    }
}
