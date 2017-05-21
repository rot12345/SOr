namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plik", "Tresc", c => c.String(maxLength: 1800));
            AddColumn("dbo.Plik", "Sciezka", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plik", "Sciezka");
            DropColumn("dbo.Plik", "Tresc");
        }
    }
}
