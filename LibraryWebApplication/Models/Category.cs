namespace LibraryWebApplication.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }

        // Navigation properties

        //public ICollection<Book> Books { get; set; }
    }
}
