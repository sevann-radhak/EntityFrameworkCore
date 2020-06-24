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

            //FirstExample();
            SecondExample();
        }

        private static void FirstExample()
        {
            Author author = CheckAuthor();
            Album album = CheckAlbum(author);
            AddSong(album);
        }

        // CRUD
        private static void SecondExample()
        {
            Author author = CreateAuthor(new Author { Name = "Iron Maiden", AboutMe = "Rock" });
            Album album = CreateAlbum(new Album
            {
                AuthorId = author.Id,
                PublishedAt = DateTime.Now,
                Title = "The Black Album"
            });

            CreateSong(new Song
            {
                AlbumId = album.Id,
                Description = "Rock In Rio",
                Duration = TimeSpan.FromSeconds(450),
                Title = "The Clansman"
            });

            Song edited = UpdateSong(1);
            bool flag = true;
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
            }
        }

        private static Album CheckAlbum(Author author)
        {
            using (var context = new ApplicationDbContext())
            {
                AlbumService albumService = new AlbumService(context);

                return !albumService.Any()
                    ? albumService.Create(new Album 
                    { 
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

        private static Album CreateAlbum(Album album)
        {
            using (var context = new ApplicationDbContext())
            {
                AlbumService albumService = new AlbumService(context);

                return albumService.Create(album);
            }
        }

        private static Author CreateAuthor(Author author)
        {
            using (var context = new ApplicationDbContext())
            {
                AuthorService authorService = new AuthorService(context);

                return authorService.Create(author);
            }
        }

        private static Song CreateSong(Song song)
        {
            using (var context = new ApplicationDbContext())
            {
                SongService songService = new SongService(context);
                return songService.Create(song);
            }
        }

        private static Song GetSong(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                SongService songService = new SongService(context);
                return songService.GetById(id);
            }
        }

        private static Song UpdateSong(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                SongService songService = new SongService(context);
                var originalEntry = songService.GetById(id);
                originalEntry.Title += " Edited";

                return songService.Update(originalEntry);
            }
        }
    }
}
