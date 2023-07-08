namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alarm : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Alarms", "Timestamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alarms", "Timestamp", c => c.DateTime(nullable: false));
        }
    }
}
