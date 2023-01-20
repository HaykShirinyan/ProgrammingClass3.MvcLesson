using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class CategoriesController1 : Controller
    {
        private ApplicationDbContext _dbContext;
        public CategoriesController1 (ApplicationDbContext dbContext)
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
