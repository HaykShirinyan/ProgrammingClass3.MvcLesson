using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;
using ProgramminClass3.MvcLesson.ViewModels;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _dbContext
                .Products
                // Include is Entity Framework term for SQL join
                .Include(product => product.Type)
                .Include(product => product.UnitOfMeasure)
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var productViewModel = new ProductViewModel
            {
                ProductTypes = _dbContext.ProductTypes.ToList(),
                UnitOfMeasures = _dbContext.UnitOfMeasures.ToList()
            };
           
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(productViewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            productViewModel.ProductTypes = _dbContext.ProductTypes.ToList();
            productViewModel.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productViewModel = new ProductViewModel
            {
                Product = _dbContext.Products.Find(id),
                ProductTypes = _dbContext.ProductTypes.ToList(),
                UnitOfMeasures = _dbContext.UnitOfMeasures.ToList()
            };

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(productViewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            productViewModel.ProductTypes = _dbContext.ProductTypes.ToList();
            productViewModel.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCofirmed(int id)
        {
            var product = _dbContext.Products.Find(id);

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
