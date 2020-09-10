using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MangaBooks.Core
{
    public class MangaB
    {
        public int Id { get; set; }
        [Required, StringLength(120)]
        public string Title { get; set; }
        [Required]
        public int Chapters { get; set; }
        public Genre Genre { get; set; }

    }
}
