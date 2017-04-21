namespace WithMe.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstWithMeDBschema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(),
                        ReqUserId = c.Int(),
                        ResUserId = c.Int(),
                        Description = c.String(nullable: false, maxLength: 140),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryTable", t => t.CategoryId)
                .ForeignKey("dbo.UserTable", t => t.ResUserId)
                .ForeignKey("dbo.UserTable", t => t.ReqUserId)
                .Index(t => t.CategoryId)
                .Index(t => t.ReqUserId)
                .Index(t => t.ResUserId);
            
            CreateTable(
                "dbo.CategoryTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Image = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Email = c.String(nullable: false, maxLength: 40),
                        Image = c.String(nullable: false, maxLength: 40),
                        DeviceName = c.String(nullable: false, maxLength: 40),
                        DeviceNumber = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoggingTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Table = c.String(nullable: false, maxLength: 40),
                        Operation = c.String(nullable: false, maxLength: 40),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityTable", "ReqUserId", "dbo.UserTable");
            DropForeignKey("dbo.ActivityTable", "ResUserId", "dbo.UserTable");
            DropForeignKey("dbo.ActivityTable", "CategoryId", "dbo.CategoryTable");
            DropIndex("dbo.ActivityTable", new[] { "ResUserId" });
            DropIndex("dbo.ActivityTable", new[] { "ReqUserId" });
            DropIndex("dbo.ActivityTable", new[] { "CategoryId" });
            DropTable("dbo.LoggingTable");
            DropTable("dbo.UserTable");
            DropTable("dbo.CategoryTable");
            DropTable("dbo.ActivityTable");
        }
    }
}
