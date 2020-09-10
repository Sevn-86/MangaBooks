using MangaBooks.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mangabooks.Data
{
    public class MangaBookDbContext : DbContext
    {
        public MangaBookDbContext(DbContextOptions<MangaBookDbContext> options) : base(options)
        {

            
        }
        public DbSet<MangaB> Mangas { get; set; } 
    }
}
