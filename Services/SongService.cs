using Persistence.Database;
using Persistence.Database.Models;

namespace Services
{
    public class SongService
    {
        private readonly ApplicationDbContext _context;

        public SongService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Song Create(Song model)
        {
            _context.Songs.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
