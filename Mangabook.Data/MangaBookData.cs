using MangaBooks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaBook.Data
{
    public interface IMangaBookData
    {
        IEnumerable<MangaB> GetAll();
    }

    public class InMemoryMangaData : IMangaBookData
    {

        readonly List<MangaB> manga;

        public InMemoryMangaData()
        {
            manga = new List<MangaB>()
            {
                new MangaB { Id = 1, Title  = "Naruto", Chapters = 700, Genre = Genre.Shinobi},
                new MangaB { Id = 2, Title  = "One Piece", Chapters = 654, Genre = Genre.Pirate},
                new MangaB { Id = 3, Title  = "Bleach", Chapters = 524, Genre = Genre.Shinigami},
            };
        }

        public IEnumerable<MangaB> GetAll()
        {
            return from m in manga
                   orderby m.Title
                   select m; 
        }
    }


}
