namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Imie");
            DropColumn("dbo.AspNetUsers", "Nazwisko");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Nazwisko", c => c.String());
            AddColumn("dbo.AspNetUsers", "Imie", c => c.String());
        }
    }
}
