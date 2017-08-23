namespace bregau_Auditplaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIntelligenceField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Intelligence", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Intelligence");
        }
    }
}
