using System.ComponentModel;

namespace LibraryWebApplication.Models
{
    public class News
    {
        public int newsID { get; set; }
        [DisplayName("Title")]
        public string title { get; set; }
        [DisplayName("Content")]
        public string content { get; set; }
        [DisplayName("Date published")]
        public DateTime publishDate { get; set; }
    }
}
