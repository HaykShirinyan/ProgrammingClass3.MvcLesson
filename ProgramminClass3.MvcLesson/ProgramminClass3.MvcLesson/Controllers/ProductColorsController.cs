using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;
using ProgramminClass3.MvcLesson.ViewModels;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductColorsController : Controller
    {
        private readonly ApplicationDbContext _dbCotnext;

        public ProductColorsController(ApplicationDbContext dbContext)
        {
            _dbCotnext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var listViewModel = new ProductColorListViewModel();

            listViewModel.ProductColors = _dbCotnext
                .ProductColors
                .Include(productColor => productColor.Color)
                .Where(productColor => productColor.ProductId == id)
                .ToList();

            listViewModel.Colors = _dbCotnext.Colors.ToList();
            listViewModel.ProductId = id;

            return View(listViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductColor productColor)
        {
            if (ModelState.IsValid)
            {

                _dbCotnext.ProductColors.Add(productColor);
                _dbCotnext.SaveChanges();

                return RedirectToAction("Index", new {id = productColor.ProductId});
            }

            return View(productColor);
        }
    }
}
