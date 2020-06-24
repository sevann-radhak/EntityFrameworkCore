using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;

namespace Persistence.Database.Configuration
{
    public class SongConfiguration
    {
        public SongConfiguration(EntityTypeBuilder<Song> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            entityBuilder.HasIndex(x => new { x.Title, x.AlbumId }).IsUnique();
        }
    }
}