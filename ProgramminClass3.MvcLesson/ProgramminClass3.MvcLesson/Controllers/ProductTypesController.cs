using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductTypesController (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var productTypes = _dbContext.ProductTypes.ToList();

            return View(productTypes);
        }

    }
}
