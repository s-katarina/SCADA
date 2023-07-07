namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DigitalInputs", "IsScanning", c => c.Boolean(nullable: false));
            DropColumn("dbo.DigitalInputs", "IsScaning");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DigitalInputs", "IsScaning", c => c.Boolean(nullable: false));
            DropColumn("dbo.DigitalInputs", "IsScanning");
        }
    }
}
