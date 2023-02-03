using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;
using ProgramminClass3.MvcLesson.ViewModels;

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
            var listViewModel = new ProductCategoryListViewModel();

            listViewModel.ProductCategories = _dbCotnext
                .ProductCategories
                .Include(productCategory => productCategory.Category)
                .Where(productCategory => productCategory.ProductId == id)
                .ToList();

            listViewModel.Categories = _dbCotnext.Categories.ToList();
            listViewModel.ProductId = id;

            return View(listViewModel);
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
