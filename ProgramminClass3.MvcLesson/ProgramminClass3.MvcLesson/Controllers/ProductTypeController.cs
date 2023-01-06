using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Data.Migrations;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductTypesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var ProductTypes = _dbContext.ProductTypes.ToList();

            return View(ProductTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductType productType)

        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductTypes.Add(productType);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(productType);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productType = _dbContext.ProductTypes.Find(id);

            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductTypes.Update(productType);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(productType);
        }
    }
}
