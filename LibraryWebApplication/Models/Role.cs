namespace LibraryWebApplication.Models
{
    public class Role
    {
        public int roleID { get; set; }
        public string roleName { get; set; }

        // Navigation property
        public virtual ICollection<User> Users { get; set; }
    }
}
