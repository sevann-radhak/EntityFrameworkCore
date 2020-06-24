using Persistence.Database;
using Persistence.Database.Models;
using System.Linq;

namespace Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Any()
        {
            return _context.Authors.Any();
        }

        public Author Create(Author model)
        {
            _context.Authors.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Author FirstOrDefault()
        {
            return _context.Authors.FirstOrDefault();
        }
    }
}
