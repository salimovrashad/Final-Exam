using Exam_Project.Context;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project.Controllers
{
    public class HomeController : Controller
    {
        BoocicDbContext _context { get; }

        public HomeController(BoocicDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Services.ToList());
        }
    }
}
