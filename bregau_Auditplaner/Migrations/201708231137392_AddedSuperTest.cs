namespace bregau_Auditplaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSuperTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SuperTest", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "SuperTest");
        }
    }
}
