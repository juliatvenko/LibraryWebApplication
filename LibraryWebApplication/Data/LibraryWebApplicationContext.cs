using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryWebApplication.Models;
using Microsoft.AspNetCore.Builder;
using System.Reflection.Emit;

namespace LibraryWebApplication.Data
{
    public class LibraryWebApplicationContext : DbContext
    {
        public LibraryWebApplicationContext(DbContextOptions<LibraryWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<LibraryWebApplication.Models.Book> Book { get; set; } = default!;

        public DbSet<LibraryWebApplication.Models.Category> Category { get; set; }

        public DbSet<LibraryWebApplication.Models.News> News { get; set; }

        public DbSet<LibraryWebApplication.Models.User> Users { get; set; }
        public DbSet<ReaderCard> ReaderCards { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
            base.OnModelCreating(builder);
            // Your customization here
        }
    }
}
