namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Plik", "UzytkownikId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plik", "UzytkownikId", c => c.Int(nullable: false));
        }
    }
}
