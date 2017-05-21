namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dostep_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Plik_Kategoria", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Spiewnik_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Tag_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Historia_Plik", "Plik_Id", "dbo.Plik");
            DropPrimaryKey("dbo.Plik");
            AlterColumn("dbo.Plik", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AlterColumn("dbo.Plik", "DataDodania", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Plik", "Id");
            AddForeignKey("dbo.Dostep_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Plik_Kategoria", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Spiewnik_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Tag_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Historia_Plik", "Plik_Id", "dbo.Plik", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historia_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Tag_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Spiewnik_Plik", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Plik_Kategoria", "Plik_Id", "dbo.Plik");
            DropForeignKey("dbo.Dostep_Plik", "Plik_Id", "dbo.Plik");
            DropPrimaryKey("dbo.Plik");
            AlterColumn("dbo.Plik", "DataDodania", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Plik", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Plik", "Id");
            AddForeignKey("dbo.Historia_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Tag_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Spiewnik_Plik", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Plik_Kategoria", "Plik_Id", "dbo.Plik", "Id");
            AddForeignKey("dbo.Dostep_Plik", "Plik_Id", "dbo.Plik", "Id");
        }
    }
}
