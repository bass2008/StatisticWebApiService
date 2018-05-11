using System.Data.Entity.Migrations;
using System.Linq;

namespace ReviewMe.DataAccess
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Visitors.Any())
            {
                context.Visitors.Add(new Models.Visitor { Name = "player1" });
                context.SaveChanges();
            }
        }
    }
}
