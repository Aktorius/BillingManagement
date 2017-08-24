namespace BillingManagement.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        BillingId = c.Int(nullable: false, identity: true),
                        Notes = c.String(),
                        BillingPhone = c.String(nullable: false),
                        DateFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateTo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SiteKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillingId)
                .ForeignKey("dbo.Sites", t => t.SiteKey, cascadeDelete: true)
                .Index(t => t.SiteKey);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MainSite = c.Boolean(nullable: false),
                        CompanyKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SiteId)
                .ForeignKey("dbo.Companies", t => t.CompanyKey, cascadeDelete: true)
                .Index(t => t.CompanyKey);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sites", "CompanyKey", "dbo.Companies");
            DropForeignKey("dbo.Billings", "SiteKey", "dbo.Sites");
            DropIndex("dbo.Sites", new[] { "CompanyKey" });
            DropIndex("dbo.Billings", new[] { "SiteKey" });
            DropTable("dbo.Companies");
            DropTable("dbo.Sites");
            DropTable("dbo.Billings");
        }
    }
}
