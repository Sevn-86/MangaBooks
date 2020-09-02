using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangaBooks.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MangaBooks.Pages
{
    public class DetailModel : PageModel
    {
        public MangaB MangaB { get; set; }

        public void OnGet(int mangaId)
        {
            MangaB = new MangaB();
            MangaB.Id = mangaId;
        }
    }
}