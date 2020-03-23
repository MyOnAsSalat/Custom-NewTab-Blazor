using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChromeNewTab.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ChromeNewTab.Web.Components
{
    public partial class BookmarksComponent
    {
        private int AdditionalRowsCount;
        private List<Bookmark> BookmarksModels;
        private bool Initialized = false;
        protected override async Task OnInitializedAsync()
        {
            BookmarksModels = await HttpClient.GetJsonAsync<List<Bookmark>>("https://localhost:6001/bookmarks/get");
            Initialized = true;
        }

        public async Task ShowNewBookmarkWindow(BookmarkIndex args)
        {
            await ShowBookmarkDialog(new Bookmark
            {
                Row = args.Row,
                Column = args.Column
            }, true);
        }

        public async Task ShowEditBookmarkWindow(Bookmark args)
        {
            await ShowBookmarkDialog(args, false);
        }

        public async Task SetBookmark(Bookmark bookmark)
        {
            var maxRows = BookmarksModels.Max(x => x.Row);
            await HttpClient.PostJsonAsync("https://localhost:6001/bookmarks/post", bookmark);
            BookmarksModels = await HttpClient.GetJsonAsync<List<Bookmark>>("https://localhost:6001/bookmarks/get");
            var diff = Math.Abs(BookmarksModels.Max(x => x.Row) - maxRows);
            AdditionalRowsCount = AdditionalRowsCount - diff >= 0 ? AdditionalRowsCount - diff : 0;
        }

        public async Task RemoveBookmark(Bookmark bookmark)
        {
            await HttpClient.DeleteAsync($@"https://localhost:6001/bookmarks/delete?id={bookmark.Id}");
            BookmarksModels = await HttpClient.GetJsonAsync<List<Bookmark>>("https://localhost:6001/bookmarks/get");
        }
    }
}