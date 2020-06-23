using Microsoft.EntityFrameworkCore;
using Persistence.Database.Models;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EntityFrameworkCoreMusic;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Song> Songs { get; set; }
    }
}
