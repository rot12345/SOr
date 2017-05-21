namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.File", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.File", "UserId", c => c.Int(nullable: false));
        }
    }
}
