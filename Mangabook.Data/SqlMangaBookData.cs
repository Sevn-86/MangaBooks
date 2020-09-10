using Mangabooks.Data;
using MangaBooks.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MangaBook.Data
{
    public class SqlMangaBookData : IMangaBookData
    {
        private readonly MangaBookDbContext db;

        public SqlMangaBookData(MangaBookDbContext db)
        {
            this.db = db;
        }

        public MangaB Add(MangaB newMangaB)
        {
            db.Add(newMangaB);
            return newMangaB;

        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public MangaB Delete(int id)
        {
            var manga = GetById(id);
            if(manga != null)
            {
                db.Mangas.Remove(manga);
            }
            return manga;
        }

        public MangaB GetById(int id)
        {
            return db.Mangas.Find(id);
        }

        public IEnumerable<MangaB> GetMangasByTitle(string title)
        {
            var query = from m in db.Mangas
                        where m.Title.StartsWith(title) || string.IsNullOrEmpty(title)
                        orderby m.Title
                        select m;
            return query;
        }

        public MangaB Update(MangaB updatedMangaB)
        {
            var entity = db.Mangas.Attach(updatedMangaB);
            entity.State = EntityState.Modified;
            return updatedMangaB;
        }
    }
}
