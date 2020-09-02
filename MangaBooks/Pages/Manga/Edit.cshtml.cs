using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangaBook.Data;
using MangaBooks.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MangaBooks.Pages.Manga
{
    public class EditModel : PageModel
    {
        private readonly IMangaBookData mangabookData;
        private readonly IHtmlHelper htmlHelper;

        public MangaB Manga { get; set; }
        public IEnumerable<SelectListItem> Genres  { get; set; }

        public EditModel(IMangaBookData mangabookData, IHtmlHelper htmlHelper)
        {
            this.mangabookData = mangabookData;
            this.htmlHelper = htmlHelper;
        }


        public IActionResult OnGet(int mangaId)
        {
            Genres = htmlHelper.GetEnumSelectList<Genre>();
            Manga = mangabookData.GetById(mangaId);
            if (Manga == null)
            {
                return RedirectToPage("./NotFound"); 
            }
            return Page();




        }
    }
}