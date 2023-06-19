using LibraryWebApplication.Data;
using LibraryWebApplication.Models;
using LibraryWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibraryWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryWebApplicationContext _context;
        private readonly VisitCounterService _visitCounterService;

        public HomeController(ILogger<HomeController> logger, LibraryWebApplicationContext context, VisitCounterService visitCounterService)
        {
            _logger = logger;
            _context = context;
            _visitCounterService = visitCounterService;
        }

        public async Task<IActionResult> Index()
        {

            return RedirectToAction("Index", "News"); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}