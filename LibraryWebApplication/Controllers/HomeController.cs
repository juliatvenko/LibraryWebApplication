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

        public class HomeNewsViewModel
        {
            public IEnumerable<News> News { get; set; }
            // Add more properties as needed for other data you want to pass to the view
        }

        public async Task<IActionResult> Index()
        {
            int visitCount = _visitCounterService.VisitCount;
            ViewData["VisitCount"] = visitCount;

            var viewModel = new HomeNewsViewModel
            {
                News = await _context.News.ToListAsync(),
            };

            return View(viewModel);
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