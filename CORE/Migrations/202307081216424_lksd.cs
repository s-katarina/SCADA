namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lksd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecordAlarms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        AlarmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alarms", t => t.AlarmId, cascadeDelete: true)
                .Index(t => t.AlarmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecordAlarms", "AlarmId", "dbo.Alarms");
            DropIndex("dbo.RecordAlarms", new[] { "AlarmId" });
            DropTable("dbo.RecordAlarms");
        }
    }
}
