using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Data.Migrations;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();

            return View(categories);
        }

        [HttpGet]       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
               return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _dbContext.Categories.Find(id);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}
