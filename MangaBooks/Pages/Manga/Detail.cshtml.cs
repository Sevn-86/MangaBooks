using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangaBook.Data;
using MangaBooks.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangaBooks.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IMangaBookData mangaData;

        [TempData]
        public string Message { get; set; }

        public DetailModel(IMangaBookData mangaData)
        {
            this.mangaData = mangaData;
        }
        public MangaB MangaB { get; set; }

        public IActionResult OnGet(int mangaId)
        {
            MangaB = mangaData.GetById(mangaId);
            if (MangaB == null)
            {
                return RedirectToPage("./NotFound");

            } 
                return Page();
            
        }
    }
}