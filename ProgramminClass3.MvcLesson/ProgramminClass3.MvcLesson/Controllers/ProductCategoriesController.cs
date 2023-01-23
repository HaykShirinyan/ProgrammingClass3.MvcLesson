using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly ApplicationDbContext _dbCotnext;

        public ProductCategoriesController(ApplicationDbContext dbCotnext)
        {
            _dbCotnext = dbCotnext;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var productCategories = _dbCotnext
                .ProductCategories
                .Include(productCategory => productCategory.Category)
                .Where(productCategory => productCategory.ProductId == id)
                .ToList();

            ViewBag.Categories = _dbCotnext.Categories.ToList();
            ViewBag.ProductId = id;

            return View(productCategories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _dbCotnext.ProductCategories.Add(productCategory);
                _dbCotnext.SaveChanges();

                return RedirectToAction("Index", new { id = productCategory.ProductId });
            }

            return View(productCategory);
        }
    }
}
