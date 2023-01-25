using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductSizesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSizesController (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var ProductSizes = _dbContext.ProductSizes
                .Include(productSize => productSize.Size)
                .Where(productSize => productSize.ProductId == id)
                .ToList();
            ViewBag.Sizes = _dbContext.Sizes.ToList();
            ViewBag.ProductId = id;

            return View(ProductSizes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductSize productSize)
        {
            if(ModelState.IsValid)
            {
                _dbContext.ProductSizes.Add(productSize);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", new {id = productSize.ProductId});
            }

            return View(productSize);
        }
    }
}
