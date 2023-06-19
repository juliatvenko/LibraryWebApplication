using System.ComponentModel;
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

        [DisplayName("Borrow date")]
        public DateTime borrowDate { get; set; }
        [DisplayName("Return date")]
        public DateTime returnDate { get; set; }
        [DisplayName("Is borrowed?")]
        public bool isBorrowed { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
