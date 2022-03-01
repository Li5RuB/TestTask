using Microsoft.EntityFrameworkCore;
using TestTask.Repository.Items;

namespace TestTask.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {
        }

        public DbSet<UserItem> Users { get; set; }

        public DbSet<CountStatisticsItem> СountStatistics { get; set; }

        public DbSet<LastLoginStatisticsItem> LastLoginStatistics { get; set; }

        public DbSet<CountryItem> Countries { get; set; }

        public DbSet<CityItem> Cities { get; set; }

        public DbSet<TitleItem> Titles { get; set; }
        
        public DbSet<RoleItem> Roles { get; set; }

        public DbSet<IssueItem> Issues { get; set; }

        public DbSet<TimeLogItem> TimeLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
