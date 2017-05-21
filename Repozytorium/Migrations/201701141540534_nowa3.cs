namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.File", "DateInsert", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "UserId", c => c.Int(nullable: false));
        }
    }
}
