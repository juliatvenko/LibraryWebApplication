using System.ComponentModel.DataAnnotations;

namespace LibraryWebApplication.Models
{
    public class EditProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]

        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
         ErrorMessage = "Password must be at least 8 characters and contain both letters and digits.")]
        public string NewPassword { get; set; }
    }
}
