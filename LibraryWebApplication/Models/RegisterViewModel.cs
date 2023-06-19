using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApplication.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
         ErrorMessage = "Password must be at least 8 characters and contain both letters and digits.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
