using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Database.Models;
using Services.Dto;
using System.Collections.Generic;
using System.Linq;

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

        public List<Song> GetAll()
        {
            return _context.Songs.Include(s => s.Album).ToList();
        }

        public List<SongDto> GetAllDto()
        {
            return _context.Songs
                .Include(s => s.Album)
                .ThenInclude(a => a.Author)
                .Select(s => new SongDto
                {
                    Album = s.Album.Title,
                    Author = s.Album.Author.Name,
                    Duration = s.Duration,
                    Name = s.Title,
                    SongId = s.Id
                })
                .ToList();
        }

        public Song GetById(int id)
        {
            return _context.Songs.Find(id);
        }

        public bool Remove(int id)
        {
            try
            {
                var originalEntry = _context.Songs.Find(id);
                _context.Songs.Remove(originalEntry);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public Song Update(Song model)
        {
            var originalEntry = _context.Songs.Find(model.Id);
            originalEntry.Description = model.Description;
            originalEntry.Duration = model.Duration;
            originalEntry.Title = model.Title;

            _context.Songs.Update(originalEntry);
            _context.SaveChanges();
            return model;
        }
    }
}
