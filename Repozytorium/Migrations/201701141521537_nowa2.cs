namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event_File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        File_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.File", t => t.File_Id)
                .Index(t => t.EventId)
                .Index(t => t.File_Id);
            
            CreateTable(
                "dbo.Event_Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        MessageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Message", t => t.MessageId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.MessageId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        DateInsert = c.DateTime(nullable: false),
                        StatusEvent = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User_Access",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AccessId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Access", t => t.AccessId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.AccessId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Access", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_Access", "AccessId", "dbo.Access");
            DropForeignKey("dbo.Event_Message", "MessageId", "dbo.Message");
            DropForeignKey("dbo.Message", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Event_Message", "EventId", "dbo.Event");
            DropForeignKey("dbo.Event_File", "File_Id", "dbo.File");
            DropForeignKey("dbo.Event_File", "EventId", "dbo.Event");
            DropIndex("dbo.User_Access", new[] { "User_Id" });
            DropIndex("dbo.User_Access", new[] { "AccessId" });
            DropIndex("dbo.Message", new[] { "User_Id" });
            DropIndex("dbo.Event_Message", new[] { "MessageId" });
            DropIndex("dbo.Event_Message", new[] { "EventId" });
            DropIndex("dbo.Event_File", new[] { "File_Id" });
            DropIndex("dbo.Event_File", new[] { "EventId" });
            DropTable("dbo.User_Access");
            DropTable("dbo.Message");
            DropTable("dbo.Event_Message");
            DropTable("dbo.Event_File");
        }
    }
}
