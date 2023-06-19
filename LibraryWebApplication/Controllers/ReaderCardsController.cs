using LibraryWebApplication.Data;
using LibraryWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication.Controllers
{
    public class ReaderCardsController : Controller
    {
        private readonly LibraryWebApplicationContext _context;

        public ReaderCardsController(LibraryWebApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("userId");

            var borrowedBooks = await _context.ReaderCards
                .Include(rc => rc.Book)
                .Where(rc => rc.userID == userId)
            .ToListAsync();

            if (borrowedBooks.Count == 0)
            {
                ViewBag.NoBorrowedBooksMessage = "You haven't borrowed anything yet.";
            }


            return View(borrowedBooks);
        }
    }
}
