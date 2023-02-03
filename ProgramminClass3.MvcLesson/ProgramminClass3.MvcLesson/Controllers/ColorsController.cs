using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ColorsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var colors = _dbContext.Colors.ToList();

            return View(colors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Color color)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Colors.Add(color);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(color);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var color = _dbContext.Colors.Find(id);

            return View(color);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Color color)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Colors.Update(color);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(color);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var color = _dbContext.Colors.Find(id);

            return View(color);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var color = _dbContext.Colors.Find(id);

            _dbContext.Colors.Remove(color);
            _dbContext.SaveChanges();

            return View("Index");
        }
    }
}
