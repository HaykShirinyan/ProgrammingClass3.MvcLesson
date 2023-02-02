using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class SizesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public SizesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var Sizes = _dbContext.Sizes.ToList();

            return View(Sizes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Size Size)

        {
            if (ModelState.IsValid)
            {
                _dbContext.Sizes.Add(Size);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(Size);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Size = _dbContext.Sizes.Find(id);

            return View(Size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Size Size)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Sizes.Update(Size);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Size);
        }
    }
}
