namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hfth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecordAlarms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecordAlarms");
        }
    }
}
