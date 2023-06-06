using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryWebApplication.Data;
using LibraryWebApplication.Models;

namespace LibraryWebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryWebApplicationContext _context;
        private IWebHostEnvironment _environment;


        public BooksController(IWebHostEnvironment environment, LibraryWebApplicationContext context)
        {
            _environment = environment;
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string titleSearchString = null, string authorSearchString = null, List<int> categoryIds = null)
        {
            var books = from b in _context.Book
                        select b;

            if (!String.IsNullOrEmpty(titleSearchString))
            {
                books = books.Where(s => s.title.Contains(titleSearchString));
            }

            if (!String.IsNullOrEmpty(authorSearchString))
            {
                books = books.Where(s => s.author.Contains(authorSearchString));
            }

            if (categoryIds != null && categoryIds.Any())
            {
                books = books.Where(b => categoryIds.Contains(b.categoryID));
            }

            ViewData["Categories"] = _context.Category.ToList();

            return View(await books.ToListAsync());
        }



        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.bookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["categoryID"] = new SelectList(_context.Set<Category>(), "categoryID", "categoryName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            ViewData["categoryID"] = new SelectList(_context.Set<Category>(), "categoryID", "categoryName");

            if (book.ImageFile != null)
            {
                try
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "Images", book.ImageFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await book.ImageFile.CopyToAsync(stream);
                    }
                    book.coverImagePath = "/Images/" + book.ImageFile.FileName;
                }
                catch (Exception e)
                {
                    ViewBag.Message = "File Saving Error: " + e.Message;
                    return View(book);
                }
            }

            if (book.coverImagePath == null)
            {
                ViewBag.Message = "The coverImagePath field is required.";
                return View(book);
            }

            try
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Message = "Database Saving Error: " + e.Message;
                return View(book);
            }
        }



        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["categoryID"] = new SelectList(_context.Set<Category>(), "categoryID", "categoryName");
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bookID,title,author,publishedYear,isAvailable,categoryID,coverImagePath")] Book book)
        {
            if (id != book.bookID)
            {
                return NotFound();
            }

            try
            {
                // Get the existing book from the database
                var existingBook = await _context.Book.FindAsync(id);

                // If a new image file is uploaded, then save it and update the coverImagePath
                var file = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;
                if (file != null && file.Length > 0)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "Images", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    existingBook.coverImagePath = "/Images/" + file.FileName;
                }

                // Update the other book properties
                existingBook.title = book.title;
                existingBook.author = book.author;
                existingBook.publishedYear = book.publishedYear;
                existingBook.isAvailable = book.isAvailable;
                existingBook.categoryID = book.categoryID;

                // Save the updated book
                _context.Update(existingBook);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.bookID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewData["categoryID"] = new SelectList(_context.Set<Category>(), "categoryID", "categoryName");
            return RedirectToAction(nameof(Index));
        }



        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.bookID == id);
            if (book == null)
            {
                return NotFound();
            }

            ViewData["categoryID"] = new SelectList(_context.Set<Category>(), "categoryID", "categoryName");
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'LibraryWebApp2Context.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return (_context.Book?.Any(e => e.bookID == id)).GetValueOrDefault();
        }
    }
}
