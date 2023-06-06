using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApplication.Models
{
    public class Book
    {
        public int bookID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int publishedYear { get; set; }
        public bool isAvailable { get; set; }
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
