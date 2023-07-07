namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnalogInputs", "Driver", c => c.Int(nullable: false));
            AddColumn("dbo.AnalogInputs", "IOAddress", c => c.String());
            AddColumn("dbo.AnalogInputs", "ScanTime", c => c.Int(nullable: false));
            AddColumn("dbo.AnalogInputs", "IsScanning", c => c.Boolean(nullable: false));
            AddColumn("dbo.AnalogInputs", "Units", c => c.String());
            AddColumn("dbo.AnalogInputs", "LowLimit", c => c.Int(nullable: false));
            AddColumn("dbo.AnalogInputs", "HighLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnalogInputs", "HighLimit");
            DropColumn("dbo.AnalogInputs", "LowLimit");
            DropColumn("dbo.AnalogInputs", "Units");
            DropColumn("dbo.AnalogInputs", "IsScanning");
            DropColumn("dbo.AnalogInputs", "ScanTime");
            DropColumn("dbo.AnalogInputs", "IOAddress");
            DropColumn("dbo.AnalogInputs", "Driver");
        }
    }
}
