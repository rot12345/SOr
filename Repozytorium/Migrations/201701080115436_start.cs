namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dostep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ident = c.String(nullable: false),
                        Nazwa = c.String(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plik", t => t.Plik_Id)
                .Index(t => t.Plik_Id);
            
            CreateTable(
                "dbo.Dostep_Spiewnik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DostepId = c.Int(nullable: false),
                        SpiewnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spiewnik", t => t.SpiewnikId, cascadeDelete: true)
                .Index(t => t.SpiewnikId);
            
            CreateTable(
                "dbo.Grupa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        DostepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dostep", t => t.DostepId, cascadeDelete: true)
                .Index(t => t.DostepId);
            
            CreateTable(
                "dbo.Grupa_Uzytkownik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrupaId = c.Int(nullable: false),
                        UzytkownikId = c.Int(nullable: false),
                        Uzytkownik_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupa", t => t.GrupaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Uzytkownik_Id)
                .Index(t => t.GrupaId)
                .Index(t => t.Uzytkownik_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.Historia_Plik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HistoriaId = c.Int(nullable: false),
                        PlikId = c.Int(nullable: false),
                        Plik_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Historia", t => t.HistoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Plik", t => t.Plik_Id)
                .Index(t => t.HistoriaId)
                .Index(t => t.Plik_Id);
            
            CreateTable(
                "dbo.Plik",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nazwa = c.String(nullable: false),
                        UzytkownikId = c.Int(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                        DataAktualizacji = c.DateTime(nullable: false),
                        TypId = c.Int(nullable: false),
                        DostepId = c.Int(nullable: false),
                        Uzytkownik_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Typ", t => t.TypId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Uzytkownik_Id)
                .Index(t => t.TypId)
                .Index(t => t.Uzytkownik_Id);
            
            CreateTable(
                "dbo.Plik_Kategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlikId = c.Int(nullable: false),
                        KategoriaId = c.Int(nullable: false),
                        Plik_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategoria", t => t.KategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Plik", t => t.Plik_Id)
                .Index(t => t.KategoriaId)
                .Index(t => t.Plik_Id);
            
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plik", t => t.Plik_Id)
                .ForeignKey("dbo.Spiewnik", t => t.SpiewnikId, cascadeDelete: true)
                .Index(t => t.SpiewnikId)
                .Index(t => t.Plik_Id);
            
            CreateTable(
                "dbo.Tag_Plik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        PlikId = c.Int(nullable: false),
                        Plik_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plik", t => t.Plik_Id)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.Plik_Id);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tag_Plik", "TagId", "dbo.Tag");
            DropForeignKey("dbo.Spiewnik_Plik", "SpiewnikId", "dbo.Spiewnik");
            DropForeignKey("dbo.Dostep_Spiewnik", "SpiewnikId", "dbo.Spiewnik");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Historia_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Plik", "Uzytkownik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Plik", "TypId", "dbo.Typ");
            DropForeignKey("dbo.Tag_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Spiewnik_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Plik_Kategoria", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Plik_Kategoria", "KategoriaId", "dbo.Kategoria");
            DropForeignKey("dbo.Dostep_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Historia_Plik", "HistoriaId", "dbo.Historia");
            DropForeignKey("dbo.Grupa_Uzytkownik", "Uzytkownik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grupa_Uzytkownik", "GrupaId", "dbo.Grupa");
            DropForeignKey("dbo.Grupa", "DostepId", "dbo.Dostep");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tag_Plik", new[] { "Plik_Id" });
            DropIndex("dbo.Tag_Plik", new[] { "TagId" });
            DropIndex("dbo.Spiewnik_Plik", new[] { "Plik_Id" });
            DropIndex("dbo.Spiewnik_Plik", new[] { "SpiewnikId" });
            DropIndex("dbo.Plik_Kategoria", new[] { "Plik_Id" });
            DropIndex("dbo.Plik_Kategoria", new[] { "KategoriaId" });
            DropIndex("dbo.Plik", new[] { "Uzytkownik_Id" });
            DropIndex("dbo.Plik", new[] { "TypId" });
            DropIndex("dbo.Historia_Plik", new[] { "Plik_Id" });
            DropIndex("dbo.Historia_Plik", new[] { "HistoriaId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Grupa_Uzytkownik", new[] { "Uzytkownik_Id" });
            DropIndex("dbo.Grupa_Uzytkownik", new[] { "GrupaId" });
            DropIndex("dbo.Grupa", new[] { "DostepId" });
            DropIndex("dbo.Dostep_Spiewnik", new[] { "SpiewnikId" });
            DropIndex("dbo.Dostep_Plik", new[] { "Plik_Id" });
            DropTable("dbo.Tag");
            DropTable("dbo.Spiewnik");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Typ");
            DropTable("dbo.Tag_Plik");
            DropTable("dbo.Spiewnik_Plik");
            DropTable("dbo.Kategoria");
            DropTable("dbo.Plik_Kategoria");
            DropTable("dbo.Plik");
            DropTable("dbo.Historia_Plik");
            DropTable("dbo.Historia");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Grupa_Uzytkownik");
            DropTable("dbo.Grupa");
            DropTable("dbo.Dostep_Spiewnik");
            DropTable("dbo.Dostep_Plik");
            DropTable("dbo.Dostep");
        }
    }
}
