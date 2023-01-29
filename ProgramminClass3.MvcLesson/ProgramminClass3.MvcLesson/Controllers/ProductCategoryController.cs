using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public  ProductCategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index (int id)
        {
            var productCategories = _dbContext
                .ProductCategories
                .Include(productCategory => productCategory.Category)
                .Where(productCategory => productCategory.ProductId == id)
                .ToList();

            ViewBag.Categories = _dbContext.Categories.ToList();
            ViewBag.ProductId = id;

            return View(productCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategory productCategory)
        {
            if(ModelState.IsValid)
            {
                _dbContext.ProductCategories.Add(productCategory);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", new { id = productCategory.ProductId });
            }

            return View(productCategory);
        }
    }
}