using GeeksForLess_TestTask.Data;
using GeeksForLess_TestTask.Interfaces;
using GeeksForLess_TestTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeeksForLess_TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ICatalogService _service;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ICatalogService service)
        {
            _logger = logger;
            _context = context;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Catalog(string? path, string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var thisFolder = _context.Catalogs.FirstOrDefault(x => x.Path == "");
                ViewBag.Name = thisFolder.Name;

                var attachedFolder = _context.Catalogs.Where(x => x.FolderId == thisFolder.Id).ToList();

                return View(attachedFolder);
            }
            else
            {

                var thisFolder = _context.Catalogs.FirstOrDefault(x => x.Path == path && x.Name == name);
                ViewBag.Name = thisFolder.Name;

                var attachedFolder = _context.Catalogs.Where(x => x.FolderId == thisFolder.Id).ToList();

                return View(attachedFolder);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}