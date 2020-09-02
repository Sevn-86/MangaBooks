using MangaBooks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaBook.Data
{
    public interface IMangaBookData
    {
        IEnumerable<MangaB> GetMangasByTitle(string title);
        MangaB GetById(int id);
    }

    public class InMemoryMangaData : IMangaBookData
    {

        readonly List<MangaB> manga;

        public InMemoryMangaData()
        {
            manga = new List<MangaB>()
            {
                new MangaB { Id = 1, Title  = "Naruto", Chapters = 700, Genre = Genre.Shinobi },
                new MangaB { Id = 2, Title  = "One Piece", Chapters = 654, Genre = Genre.Pirate },
                new MangaB { Id = 3, Title  = "Bleach", Chapters = 524, Genre = Genre.Shinigami },
                new MangaB { Id = 4, Title = "ISR", Chapters = 3400, Genre = Genre.Romance },
            };
        }

        public MangaB GetById(int id)
        {
            return manga.SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<MangaB> GetMangasByTitle(string title = null)
        {
            return from m in manga
                   where string.IsNullOrEmpty(title) || m.Title.StartsWith(title)
                   orderby m.Title
                   select m; 
        }
    }


}
