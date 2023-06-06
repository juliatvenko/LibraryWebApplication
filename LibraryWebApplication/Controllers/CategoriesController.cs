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
    public class CategoriesController : Controller
    {
        private readonly LibraryWebApplicationContext _context;

        public CategoriesController(LibraryWebApplicationContext context)
        {
            _context = context;
        }


        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("categoryName")] Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            Console.WriteLine($"{state.Key} : {error.ErrorMessage}");
                        }
                    }
                }

                if (ModelState.IsValid)
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Books");
                }
                return View(category);
            }
            catch (Exception ex)
            {
                // Store the error message in the ViewBag
                ViewBag.ErrorMessage = ex.Message;
                return View(category);
            }
        }

        private bool CategoryExists(int id)
        {
            return (_context.Category?.Any(e => e.categoryID == id)).GetValueOrDefault();
        }
    }
}
