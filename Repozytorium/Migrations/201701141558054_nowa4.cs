namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.File", "DateInsert", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
        }
    }
}
