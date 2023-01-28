using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ColorsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var colors = _dbContext.Colors.ToList();

            return View(colors);
        }
    }
}
