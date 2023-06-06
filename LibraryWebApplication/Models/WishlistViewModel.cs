namespace LibraryWebApplication.Models
{
    public class WishlistViewModel
    {
        public User User { get; set; }
        public List<Book> Books { get; set; }  // All the books in the user's Wishlist
    }
}
