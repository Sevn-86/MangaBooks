using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MangaBooks.Core;
using MangaBook.Data;

namespace MangaBooks.Pages.Manga
{
    public class EditModel : PageModel
    {
        private readonly IMangaBookData mangabookData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public MangaB Manga { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

        public EditModel(IMangaBookData mangabookData, IHtmlHelper htmlHelper)
        {
            this.mangabookData = mangabookData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? mangaId)
        {
            Genres = htmlHelper.GetEnumSelectList<Genre>();
            if (mangaId.HasValue)
            {


                Manga = mangabookData.GetById(mangaId.Value);
            }
            else
            {
                Manga = new MangaB();

            }
                if (Manga == null)
            {
                return RedirectToPage("./NotFound"); 
            }
            return Page();
        }

      public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Genres = htmlHelper.GetEnumSelectList<Genre>();
                return Page();
            }
            if (Manga.Id > 0) 
            {
                mangabookData.Update(Manga);
            }
            else
            {
                mangabookData.Add(Manga);
            }
            mangabookData.Commit();
            TempData["Message"] = "Manga Saved!";
            return RedirectToPage("/Detail", new { mangaId = Manga.Id });
        }
    }
}