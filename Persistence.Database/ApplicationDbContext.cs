using Microsoft.EntityFrameworkCore;
using Persistence.Database.Configuration;
using Persistence.Database.Models;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EntityFrameworkCoreMusic;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            new AuthorConfiguration(builder.Entity<Author>());
            new AlbumConfiguration(builder.Entity<Album>());
            new SongConfiguration(builder.Entity<Song>());

            base.OnModelCreating(builder);
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
