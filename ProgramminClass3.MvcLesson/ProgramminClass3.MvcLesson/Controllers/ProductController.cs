using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgrammClass3.MvcLesson.Controllers
{
    public class ProductController : Controllers
    {
        private AppLicationDbContext _dbContext;

        public  ProductController(AppLicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.ToList();

            return View(products);
        }
    }
}