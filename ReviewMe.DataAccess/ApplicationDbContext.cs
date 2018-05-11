using ReviewMe.DataAccess;
using ReviewMe.DataAccess.Models;
using System.Data.Entity;

namespace ReviewMe
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public ApplicationDbContext() : base("ReviewMe")
        {

        }
    }
}