namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plik", "DataDodania", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
        }
    }
}
