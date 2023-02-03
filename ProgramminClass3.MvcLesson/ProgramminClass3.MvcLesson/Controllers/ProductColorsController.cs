using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;
using ProgramminClass3.MvcLesson.ViewModels;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductColorsController : Controller
    {
        private ApplicationDbContext _dbContext;
        public ProductColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var productColorViewModel = new ProductColorListViewModel
            {
                ProductColors = _dbContext
                    .ProductColors
                    .Include(productColor => productColor.Color)
                    .Where(productColor => productColor.ProductId == id)
                    .ToList(),
                Colors = _dbContext.Colors.ToList(),
                ProductId = id
            };

            return View(productColorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductColors.Add(productColor);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", new { id = productColor.ProductId });
            }

            return View(productColor);
        }
    }
}
