using MangaBooks.Core;
using System.Collections.Generic;
using System.Text;

namespace MangaBook.Data
{
    public interface IMangaBookData
    {
        IEnumerable<MangaB> GetMangasByTitle(string title);
        MangaB GetById(int id);
        MangaB Update(MangaB updatedMangaB);
        MangaB Add(MangaB newMangaB);
        MangaB Delete(int id);
        int Commit();
    }


}
