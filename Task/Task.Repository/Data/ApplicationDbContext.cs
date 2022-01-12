using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;

namespace Task.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserItem> Users { get; set; }

        public DbSet<CountryItem> Countries { get; set; }

        public DbSet<CityItem> Cities { get; set; }

        public DbSet<TitleItem> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestTask;User Id=koshin;password=Qwe123!@#;MultipleActiveResultSets=true");
        }
        //Server=(localdb)\\mssqllocaldb;Database=TestTask;Trusted_Connection=True;MultipleActiveResultSets=true
    }
}
