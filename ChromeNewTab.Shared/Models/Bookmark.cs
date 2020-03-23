using System;
using System.ComponentModel.DataAnnotations;
namespace ChromeNewTab.Shared.Models
{
    public class Bookmark
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
