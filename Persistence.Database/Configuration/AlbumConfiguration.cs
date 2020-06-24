using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;

namespace Persistence.Database.Configuration
{
    public class AlbumConfiguration
    {
        public AlbumConfiguration(EntityTypeBuilder<Album> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            entityBuilder.HasQueryFilter(x => !x.Deleted);
        }
    }
}