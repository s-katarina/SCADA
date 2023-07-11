namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alarmchang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alarms", "Timestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alarms", "Timestamp");
        }
    }
}
