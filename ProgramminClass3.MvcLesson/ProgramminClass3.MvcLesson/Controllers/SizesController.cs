using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class SizesController : Controller
    {
        public class SizessController : Controller
        {
            private ApplicationDbContext _dbContext;
            public SizessController(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public IActionResult Index()
            {
                var sizes = _dbContext.Sizes.ToList();
                return View(sizes);
            }
        }
    }
}
