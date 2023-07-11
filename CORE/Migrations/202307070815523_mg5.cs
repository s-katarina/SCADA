namespace CORE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg5 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Nestoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Nestoes",
                c => new
                    {
                        Polje = c.String(nullable: false, maxLength: 128),
                        Polje2 = c.String(),
                    })
                .PrimaryKey(t => t.Polje);
            
        }
    }
}
