using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChromeNewTab.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChromeNewTab.Server.Db
{
    public class BookmarksDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=app.db");
        }
        public virtual DbSet<Bookmark> Bookmarks {get;set;}
    }
}
