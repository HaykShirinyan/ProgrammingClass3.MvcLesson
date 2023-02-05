using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ProductColorsController : Controller
    {
        private readonly ApplicationDbContext _dbCotnext;
        public ProductColorsController(ApplicationDbContext dbCotnext)
        {
            _dbCotnext = dbCotnext;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var productColors = _dbCotnext
                .ProductColors
                .Include(productColor => productColor.Color)
                .Where(productColor => productColor.ProductId == id)
                .ToList();

            ViewBag.Colors = _dbCotnext.Colors.ToList();
            ViewBag.ProductId = id;

            return View(productColors);
        }
    }
}
