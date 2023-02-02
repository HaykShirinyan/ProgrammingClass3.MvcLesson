using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            var Colors = _dbContext.Colors.ToList();

            return View(Colors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Color Color)

        {
            if (ModelState.IsValid)
            {
                _dbContext.Colors.Add(Color);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(Color);
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
    }
}
