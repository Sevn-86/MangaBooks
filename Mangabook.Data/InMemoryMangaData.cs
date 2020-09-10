using MangaBooks.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MangaBook.Data
{
    public class InMemoryMangaData : IMangaBookData
    {

        readonly List<MangaB> mangas;

        public InMemoryMangaData()
        {
            mangas = new List<MangaB>()
            {
                new MangaB { Id = 1, Title  = "Naruto", Chapters = 700, Genre = Genre.Shinobi },
                new MangaB { Id = 2, Title  = "One Piece", Chapters = 654, Genre = Genre.Pirate },
                new MangaB { Id = 3, Title  = "Bleach", Chapters = 524, Genre = Genre.Shinigami },
                new MangaB { Id = 4, Title = "ISR", Chapters = 3400, Genre = Genre.Romance },
            };
        }

        public MangaB GetById(int id)
        {
            return mangas.SingleOrDefault(m => m.Id == id);
        }

        public MangaB Add(MangaB newMangaB)
        {
            mangas.Add(newMangaB);
            newMangaB.Id = mangas.Max(m => m.Id) + 1;
            return newMangaB;
        }

        public MangaB Update(MangaB updatedMangaB)
        {
            var manga = mangas.SingleOrDefault(m => m.Id == updatedMangaB.Id);  
            if(manga != null)
            {
                manga.Title = updatedMangaB.Title;
                manga.Chapters = updatedMangaB.Chapters;
                manga.Genre = updatedMangaB.Genre;
            }
            return manga; 
        }

        public int Commit()
        {
            return 0;
        }


        public IEnumerable<MangaB> GetMangasByTitle(string title = null)
        {
            return from m in mangas
                   where string.IsNullOrEmpty(title) || m.Title.StartsWith(title)
                   orderby m.Title
                   select m; 
        }

        public MangaB Delete(int id)
        {
            var manga = mangas.FirstOrDefault(m => m.Id == id);
            if(manga != null)
            {
                mangas.Remove(manga);
            }
            return manga;
        }
    }


}
