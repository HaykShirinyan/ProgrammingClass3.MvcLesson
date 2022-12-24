using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();

            return View(categories);
        }
    }
}
