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

        [HttpGet]
        public IActionResult Index()
        {
            var sizes = _dbContext.Sizes.ToList();

            return View(sizes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Size size)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Sizes.Add(size);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(size);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var size = _dbContext.Sizes.Find(id);

            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Size size)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Sizes.Update(size);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(size);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var size = _dbContext.Sizes.Find(id);

            return View(size);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletConfirmed(int id)
        {
            var size = _dbContext.Sizes.Find(id);

            _dbContext.Sizes.Remove(size);
            _dbContext.SaveChanges();

            return View("Index");
        }

    }
}
