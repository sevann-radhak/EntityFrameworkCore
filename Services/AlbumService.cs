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
    }
}
