using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApplication.Models
{
    public class Book
    {
        public int bookID { get; set; }

        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Author")]
        public string author { get; set; }

        [DisplayName("Year published")]
        public int publishedYear { get; set; }

        [DisplayName("Is available?")]
        public bool isAvailable { get; set; }

        [DisplayName("Category")]
        public int categoryID { get; set; }
        public string coverImagePath { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public ICollection<ReaderCard> Cards { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
