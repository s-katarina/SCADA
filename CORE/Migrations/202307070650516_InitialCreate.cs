namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alarms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Limit = c.Double(nullable: false),
                        AnalogInput_TagName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnalogInputs", t => t.AnalogInput_TagName)
                .Index(t => t.AnalogInput_TagName);
            
            CreateTable(
                "dbo.AnalogInputs",
                c => new
                    {
                        TagName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Driver = c.Int(nullable: false),
                        IOAddress = c.String(),
                        ScanTime = c.Int(nullable: false),
                        IsScanning = c.Boolean(nullable: false),
                        Units = c.String(),
                        LowLimit = c.Int(nullable: false),
                        HighLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagName);
            
            CreateTable(
                "dbo.AnalogOutputs",
                c => new
                    {
                        TagName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        IOAddress = c.String(),
                        Units = c.String(),
                        InitialValue = c.Int(nullable: false),
                        LowLimit = c.Int(nullable: false),
                        HighLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagName);
            
            CreateTable(
                "dbo.DigitalInputs",
                c => new
                    {
                        TagName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Driver = c.Int(nullable: false),
                        IOAddress = c.String(),
                        ScanTime = c.Int(nullable: false),
                        IsScaning = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TagName);
            
            CreateTable(
                "dbo.DigitalOutputs",
                c => new
                    {
                        TagName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        IOAddress = c.String(),
                        InitialValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarms", "AnalogInput_TagName", "dbo.AnalogInputs");
            DropIndex("dbo.Alarms", new[] { "AnalogInput_TagName" });
            DropTable("dbo.DigitalOutputs");
            DropTable("dbo.DigitalInputs");
            DropTable("dbo.AnalogOutputs");
            DropTable("dbo.AnalogInputs");
            DropTable("dbo.Alarms");
        }
    }
}
