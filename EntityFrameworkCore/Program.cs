using Persistence.Database;
using Persistence.Database.Models;
using Services;
using System;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Author author = CheckAuthor();
            Album album = CheckAlbum(author);
            AddSong(album);
        }

        private static Album CheckAlbum(Author author)
        {
            using (var context = new ApplicationDbContext())
            {
                AlbumService albumService = new AlbumService(context);

                return !albumService.Any()
                    ? albumService.Create(new Album 
                    { 
                        //Author = author, 
                        AuthorId = author.Id, 
                        Title = "First Song"
                    })
                    : albumService.FirstOrDefault();
            }
        }

        private static Author CheckAuthor()
        {
            using (var context = new ApplicationDbContext())
            {
                AuthorService authorService = new AuthorService(context);

                return !authorService.Any()
                    ? authorService.Create(new Author { Name = "Author 1" })
                    : authorService.FirstOrDefault();
            }
        }

        private static void AddSong(Album album)
        {
            using (var context = new ApplicationDbContext())
            {
                SongService songService = new SongService(context);
                songService.Create(new Song
                {
                    AlbumId = album.Id,
                    Description = "Third Song Description",
                    Duration = TimeSpan.FromSeconds(250),
                    Title = "Third Song Title"
                });

                //context.Add(new Song
                //{
                //    Description = "First Song Description",
                //    Duration = TimeSpan.FromSeconds(250),
                //    Title = "First Song Title"
                //});

                //context.SaveChanges();
            }
        }
    }
}
