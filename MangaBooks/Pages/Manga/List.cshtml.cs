using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangaBook.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MangaBooks.Core;

namespace MangaBooks.Pages.Manga
{
    public class ListModel : PageModel
    {
        private readonly IMangaBookData mangabookData;

        public IEnumerable<MangaB> Mangas { get; set; }
        

        public ListModel(IMangaBookData mangabookData)
        {
            this.mangabookData = mangabookData;
        }
        public void OnGet()
        {
            Mangas = mangabookData.GetAll();
        }
    }
}
