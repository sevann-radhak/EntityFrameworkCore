using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Database.Models;
using System.Linq;

namespace Services
{
    public class AlbumService
    {
        private readonly ApplicationDbContext _context;

        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Any()
        {
            return _context.Albums.Any();
        }

        public Album Create(Album model)
        {
            _context.Albums.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Album FirstOrDefault()
        {
            return _context.Albums.FirstOrDefault();
        }

        public void SetTotalSongs(int albumId)
        {
            _context.Database.ExecuteSqlCommand("USP_CountSongsByAlbum @p0", albumId);

            // Stored procedure in DB
            //   ALTER PROCEDURE USP_CountSongsByAlbum
            //   @ID int
            //   AS

            //   UPDATE Albums

            //   SET TotalSongs = (SELECT COUNT(*) FROM Songs WHERE AlbumId = @ID)
            //   WHERE Id = @ID;

        }
    }
}
