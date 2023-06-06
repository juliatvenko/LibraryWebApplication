using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApplication.Models
{
    [Table("ReaderCard")]
    public class ReaderCard
    {
        [Key]
        public int recordID { get; set; }
        public int userID { get; set; }
        public int bookID { get; set; }
        public DateTime borrowDate { get; set; }
        public DateTime returnDate { get; set; }
        public bool isBorrowed { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
