using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ChromeNewTab.Server.Db;
using ChromeNewTab.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChromeNewTab.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookmarksController : ControllerBase
    {
        private BookmarksDbContext db = new BookmarksDbContext();
        public BookmarksController()
        {
            
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Bookmark> Get()
        {
            return db.Bookmarks;
        }
        [HttpPost]
        [Route("Post")]
        public async void Post([FromBody] Bookmark value)
        {
           var bm = db.Bookmarks.FirstOrDefault(x => x.Row == value.Row && x.Column == value.Column);
           if(bm != null) db.Bookmarks.Remove(bm);
           db.Bookmarks.Add(value);
           await db.SaveChangesAsync();
        }
        [HttpDelete]
        [Route("Delete")]
        public async void Delete(int id)
        {
            var bm = db.Bookmarks.FirstOrDefault(x => x.Id == id);
            if(bm != null) db.Bookmarks.Remove(bm);
            await db.SaveChangesAsync();
        }
        
        [HttpGet]
        [Route("test")]
        public void Test()
        {
            db.Bookmarks.Add(new Bookmark
            {
                Url = "https://yandex.ru/",
                ImageUrl = "https://yandex.ru/images/_crpd/6DgEdj545/71d157c9g/zmkDDDF59sItg2EEHTZ1oqQYboCwlXpPKpLuWuQaidRXADH3UfkgxV_bBoRVVWirHZdwt3-G3S0xtwLJHjDbNcdNQ1EZJL_KOLNgFEFKWaPVbU_NycQ",
                Title = "Yandex",
                Column = 0,
                Row = 0,
            });
            db.SaveChanges();
        }
    }
}
