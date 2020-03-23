using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ChromeNewTab.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ChromeNewTab.Web.Components
{
    public partial class EditBookmarkDialogue
    {
        [Parameter] [Required] public bool IsNew { get; set; } = false;

        [Parameter] [Required] public Bookmark Bookmark { get; set; }

        [Parameter] public EventCallback<Bookmark> OnSetBookmark { get; set; }

        [Parameter] public EventCallback<Bookmark> OnRemoveBookmark { get; set; }

        protected override async Task OnInitializedAsync()
        {
        }

        private void Change(string value, string name)
        {
            switch (name)
            {
                case "Title":
                    Bookmark.Title = value;
                    break;
                case "ImageUrl":
                    Bookmark.ImageUrl = (value.Contains("http") ? "" : "https://") + value;
                    break;
                case "Url":
                    Bookmark.Url = (value.Contains("http") ? "" : "https://") + value;
                    break;
            }

            StateHasChanged();
        }

        public void SetBookmark()
        {
            OnSetBookmark.InvokeAsync(Bookmark);
        }

        public void RemoveBookMark()
        {
            OnRemoveBookmark.InvokeAsync(Bookmark);
        }
    }
}