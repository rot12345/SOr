namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plik", "DataAktualizacji", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plik", "DataAktualizacji", c => c.DateTime(nullable: false));
        }
    }
}
