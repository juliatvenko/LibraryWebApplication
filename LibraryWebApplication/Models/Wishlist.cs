using System.ComponentModel.DataAnnotations;

namespace LibraryWebApplication.Models
{
    public class Wishlist
    {
        [Key]
        public int wishlistID { get; set; }
        public int userID { get; set; }
        public int bookID { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
