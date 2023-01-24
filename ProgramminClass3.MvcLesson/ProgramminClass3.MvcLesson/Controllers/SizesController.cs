using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class SizesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public SizesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sizes = _dbContext.Sizes.ToList();

            return View(sizes);
        }
    }
}
