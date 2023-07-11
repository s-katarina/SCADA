namespace CORE.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CORE.Database.IODatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CORE.Database.IODatabase";
        }

        protected override void Seed(CORE.Database.IODatabase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
