namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grupa", "DostepId", "dbo.Dostep");
            DropForeignKey("dbo.Grupa_Uzytkownik", "GrupaId", "dbo.Grupa");
            DropForeignKey("dbo.Grupa_Uzytkownik", "Uzytkownik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Historia_Plik", "HistoriaId", "dbo.Historia");
            DropForeignKey("dbo.Dostep_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Plik_Kategoria", "KategoriaId", "dbo.Kategoria");
            DropForeignKey("dbo.Plik_Kategoria", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Spiewnik_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Tag_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Plik", "TypId", "dbo.Typ");
            DropForeignKey("dbo.Plik", "Uzytkownik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Historia_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Dostep_Spiewnik", "SpiewnikId", "dbo.Spiewnik");
            DropForeignKey("dbo.Spiewnik_Plik", "SpiewnikId", "dbo.Spiewnik");
            DropForeignKey("dbo.Tag_Plik", "TagId", "dbo.Tag");
            DropIndex("dbo.Dostep_Plik", new[] { "Plik_Id" });
            DropIndex("dbo.Dostep_Spiewnik", new[] { "SpiewnikId" });
            DropIndex("dbo.Grupa", new[] { "DostepId" });
            DropIndex("dbo.Grupa_Uzytkownik", new[] { "GrupaId" });
            DropIndex("dbo.Grupa_Uzytkownik", new[] { "Uzytkownik_Id" });
            DropIndex("dbo.Historia_Plik", new[] { "HistoriaId" });
            DropIndex("dbo.Historia_Plik", new[] { "Plik_Id" });
            DropIndex("dbo.Plik", new[] { "TypId" });
            DropIndex("dbo.Plik", new[] { "Uzytkownik_Id" });
            DropIndex("dbo.Plik_Kategoria", new[] { "KategoriaId" });
            DropIndex("dbo.Plik_Kategoria", new[] { "Plik_Id" });
            DropIndex("dbo.Spiewnik_Plik", new[] { "SpiewnikId" });
            DropIndex("dbo.Spiewnik_Plik", new[] { "Plik_Id" });
            DropIndex("dbo.Tag_Plik", new[] { "TagId" });
            DropIndex("dbo.Tag_Plik", new[] { "Plik_Id" });
            CreateTable(
                "dbo.Access",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ident = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Access_File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccessId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        File_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Access", t => t.AccessId, cascadeDelete: true)
                .ForeignKey("dbo.File", t => t.File_Id)
                .Index(t => t.AccessId)
                .Index(t => t.File_Id);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateInsert = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                        AccessId = c.Int(nullable: false),
                        Content = c.String(maxLength: 1800),
                        Path = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.File_Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        File_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.File", t => t.File_Id)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.File_Id);
            
            CreateTable(
                "dbo.Group_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.GroupId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AccessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Access", t => t.AccessId, cascadeDelete: true)
                .Index(t => t.AccessId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                        DateEvent = c.DateTime(),
                        DateUpdate = c.DateTime(),
                        AccessId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        StatusEvent = c.String(),
                        Description = c.String(),
                        IsEnded = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tag", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Tag", "Nazwa");
            DropTable("dbo.Dostep");
            DropTable("dbo.Dostep_Plik");
            DropTable("dbo.Dostep_Spiewnik");
            DropTable("dbo.Grupa");
            DropTable("dbo.Grupa_Uzytkownik");
            DropTable("dbo.Historia");
            DropTable("dbo.Historia_Plik");
            DropTable("dbo.Plik");
            DropTable("dbo.Plik_Kategoria");
            DropTable("dbo.Kategoria");
            DropTable("dbo.Spiewnik_Plik");
            DropTable("dbo.Tag_Plik");
            DropTable("dbo.Typ");
            DropTable("dbo.Spiewnik");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Spiewnik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ident = c.Int(nullable: false),
                        Nazwa = c.String(nullable: false),
                        UzytkownikId = c.Int(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Typ",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ident = c.Int(nullable: false),
                        Nazwa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag_Plik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        PlikId = c.Int(nullable: false),
                        Plik_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Spiewnik_Plik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpiewnikId = c.Int(nullable: false),
                        PlikId = c.Int(nullable: false),
                        Plik_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plik_Kategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlikId = c.Int(nullable: false),
                        KategoriaId = c.Int(nullable: false),
                        Plik_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plik",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                        DataAktualizacji = c.DateTime(),
                        TypId = c.Int(nullable: false),
                        DostepId = c.Int(nullable: false),
                        Tresc = c.String(maxLength: 1800),
                        Sciezka = c.String(),
                        Uzytkownik_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Historia_Plik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HistoriaId = c.Int(nullable: false),
                        PlikId = c.Int(nullable: false),
                        Plik_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Historia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlikId = c.Int(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grupa_Uzytkownik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrupaId = c.Int(nullable: false),
                        UzytkownikId = c.Int(nullable: false),
                        Uzytkownik_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grupa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        DostepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dostep_Spiewnik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DostepId = c.Int(nullable: false),
                        SpiewnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dostep_Plik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DostepId = c.Int(nullable: false),
                        PlikId = c.Int(nullable: false),
                        Plik_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dostep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ident = c.String(nullable: false),
                        Nazwa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tag", "Nazwa", c => c.String(nullable: false));
            DropForeignKey("dbo.Group_User", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Group_User", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Group", "AccessId", "dbo.Access");
            DropForeignKey("dbo.File", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.File_Tag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.File_Tag", "File_Id", "dbo.File");
            DropForeignKey("dbo.Access_File", "File_Id", "dbo.File");
            DropForeignKey("dbo.Access_File", "AccessId", "dbo.Access");
            DropIndex("dbo.Group", new[] { "AccessId" });
            DropIndex("dbo.Group_User", new[] { "User_Id" });
            DropIndex("dbo.Group_User", new[] { "GroupId" });
            DropIndex("dbo.File_Tag", new[] { "File_Id" });
            DropIndex("dbo.File_Tag", new[] { "TagId" });
            DropIndex("dbo.File", new[] { "User_Id" });
            DropIndex("dbo.Access_File", new[] { "File_Id" });
            DropIndex("dbo.Access_File", new[] { "AccessId" });
            DropColumn("dbo.Tag", "Name");
            DropTable("dbo.Event");
            DropTable("dbo.Group");
            DropTable("dbo.Group_User");
            DropTable("dbo.File_Tag");
            DropTable("dbo.File");
            DropTable("dbo.Access_File");
            DropTable("dbo.Access");
            CreateIndex("dbo.Tag_Plik", "Plik_Id");
            CreateIndex("dbo.Tag_Plik", "TagId");
            CreateIndex("dbo.Spiewnik_Plik", "Plik_Id");
            CreateIndex("dbo.Spiewnik_Plik", "SpiewnikId");
            CreateIndex("dbo.Plik_Kategoria", "Plik_Id");
            CreateIndex("dbo.Plik_Kategoria", "KategoriaId");
            CreateIndex("dbo.Plik", "Uzytkownik_Id");
            CreateIndex("dbo.Plik", "TypId");
            CreateIndex("dbo.Historia_Plik", "Plik_Id");
            CreateIndex("dbo.Historia_Plik", "HistoriaId");
            CreateIndex("dbo.Grupa_Uzytkownik", "Uzytkownik_Id");
            CreateIndex("dbo.Grupa_Uzytkownik", "GrupaId");
            CreateIndex("dbo.Grupa", "DostepId");
            CreateIndex("dbo.Dostep_Spiewnik", "SpiewnikId");
            CreateIndex("dbo.Dostep_Plik", "Plik_Id");
            AddForeignKey("dbo.Tag_Plik", "TagId", "dbo.Tag", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Spiewnik_Plik", "SpiewnikId", "dbo.Spiewnik", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Dostep_Spiewnik", "SpiewnikId", "dbo.Spiewnik", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Historia_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Plik", "Uzytkownik_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Plik", "TypId", "dbo.Typ", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tag_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Spiewnik_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Plik_Kategoria", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Plik_Kategoria", "KategoriaId", "dbo.Kategoria", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Dostep_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Historia_Plik", "HistoriaId", "dbo.Historia", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Grupa_Uzytkownik", "Uzytkownik_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Grupa_Uzytkownik", "GrupaId", "dbo.Grupa", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Grupa", "DostepId", "dbo.Dostep", "Id", cascadeDelete: true);
        }
    }
}
