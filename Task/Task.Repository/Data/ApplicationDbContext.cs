using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserItem> Users { get; set; }

        public DbSet<CountStatisticsItem> countStatistics { get; set; }

        public DbSet<LastLoginStatisticsItem> lastLoginStatistics { get; set; }

        public DbSet<CountryItem> Countries { get; set; }

        public DbSet<CityItem> Cities { get; set; }

        public DbSet<TitleItem> Titles { get; set; }
        
        public DbSet<RoleItem> Roles { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
