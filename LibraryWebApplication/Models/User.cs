using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApplication.Models
{
    public class User
    {
        public int userID { get; set; }

        [DisplayName("First name")]
        public string firstName { get; set; }

        [DisplayName("Last name")]
        public string lastName { get; set; }

        [Phone]
        [DisplayName("Phone number")]
        public string phoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
         ErrorMessage = "Password must be at least 8 characters and contain both letters and digits.")]
        public string Password { get; set; }

        [DisplayName("Is blocked?")]
        public bool isBlocked { get; set; }

        // Foreign Key
        public int roleID { get; set; }

        // Navigation property
        public virtual Role Role { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
