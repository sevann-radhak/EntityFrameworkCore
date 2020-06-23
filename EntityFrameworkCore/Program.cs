using Persistence.Database;
using Persistence.Database.Models;
using System;

namespace EntityFrameworkCore
{
    class Program
    {
        private readonly ApplicationDbContext _context;

        public Program(ApplicationDbContext context)
        {
            _context = context;
            //AddSong();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new ApplicationDbContext())
            {
                context.Add(new Song
                {
                    Description = "First Song Description",
                    Duration = TimeSpan.FromSeconds(250),
                    Title = "First Song Title"
                });

                context.SaveChanges();
            }
        }

        //private void AddSong()
        //{
        //    _context.Add(new Song { 
        //        Description = "First Song Description",
        //        Duration = TimeSpan.FromSeconds(250),
        //        Title = "First Song Title"
        //    });
        //}
    }
}
