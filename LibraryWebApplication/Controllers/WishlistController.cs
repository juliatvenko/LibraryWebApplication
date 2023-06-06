using LibraryWebApplication.Data;
using LibraryWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryWebApplication.Controllers
{
    public class WishlistController : Controller
    {
        private readonly LibraryWebApplicationContext _context;
        private IWebHostEnvironment _environment;


        public WishlistController(IWebHostEnvironment environment, LibraryWebApplicationContext context)
        {
            _environment = environment;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get the logged-in user's ID
            var userId = HttpContext.Session.GetInt32("userId");

            // Retrieve user and their wishlist from database...
            var user = await _context.Users
                .Include(u => u.Wishlist)
                .ThenInclude(w => w.Book)
                .FirstOrDefaultAsync(u => u.userID == userId);

            // If the user has no wishlist or it's empty, set a ViewBag property
            if (user.Wishlist == null || !user.Wishlist.Any())
            {
                ViewBag.WishlistEmptyMessage = "Your wishlist is currently empty.";
            }

            // If you have a specific ViewModel for this View, create and populate it here
            var viewModel = new WishlistViewModel
            {
                User = user,
                Books = user.Wishlist?.Select(w => w.Book).ToList() ?? new List<Book>()
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddToWishlist(int bookId)
        {
            // Get the logged-in user's ID
            var userId = HttpContext.Session.GetInt32("userId");

            // Retrieve user from database...
            var user = await _context.Users
                .Include(u => u.Wishlist)
                .FirstOrDefaultAsync(u => u.userID == userId);

            // Check if the book already exists in the wishlist
            if (user.Wishlist.Any(w => w.bookID == bookId))
            {
                // The book is already in the wishlist, so we don't add it again
                // Redirect to the wishlist view or display an appropriate message
                return RedirectToAction("Index", "Books");
            }

            // Retrieve book from database...
            var book = await _context.Book.FirstOrDefaultAsync(b => b.bookID == bookId);

            // Create a new wishlist item
            var wishlistItem = new Wishlist
            {
                userID = userId.Value,
                bookID = bookId,
                User = user,
                Book = book
            };

            // Add to user's wishlist
            user.Wishlist.Add(wishlistItem);

            // Save changes
            await _context.SaveChangesAsync();

            // Redirect to the wishlist view
            return RedirectToAction("Index", "Books");
        }

    }
}
