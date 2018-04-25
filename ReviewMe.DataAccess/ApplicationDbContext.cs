using ReviewMe.DataAccess;
using ReviewMe.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReviewMe
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public ApplicationDbContext() : base("ReviewMe")
        {

        }
    }
}