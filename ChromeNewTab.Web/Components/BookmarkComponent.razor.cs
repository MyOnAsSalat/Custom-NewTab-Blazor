using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ChromeNewTab.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ChromeNewTab.Web.Components
{
    public partial class BookmarkComponent
    {
        [Parameter] public Bookmark Model { get; set; }

        [Parameter] [Required] public int Row { get; set; }

        [Parameter] [Required] public int Column { get; set; }

        [Parameter] public EventCallback<BookmarkIndex> OnClick { get; set; }

        [Parameter] public EventCallback<Bookmark> OnEditClick { get; set; }

        protected override async Task OnInitializedAsync()
        {
        }

        public void IconClick()
        {
            OnClick.InvokeAsync(new BookmarkIndex {Row = Row, Column = Column});
        }

        public void EditIconClick()
        {
            OnEditClick.InvokeAsync(Model);
        }
    }

    public class BookmarkIndex
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }
}