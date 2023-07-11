namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Alarms", name: "AnalogInput_TagName", newName: "InputTagName");
            RenameIndex(table: "dbo.Alarms", name: "IX_AnalogInput_TagName", newName: "IX_InputTagName");
            CreateTable(
                "dbo.Nestoes",
                c => new
                    {
                        Polje = c.String(nullable: false, maxLength: 128),
                        Polje2 = c.String(),
                    })
                .PrimaryKey(t => t.Polje);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nestoes");
            RenameIndex(table: "dbo.Alarms", name: "IX_InputTagName", newName: "IX_AnalogInput_TagName");
            RenameColumn(table: "dbo.Alarms", name: "InputTagName", newName: "AnalogInput_TagName");
        }
    }
}
