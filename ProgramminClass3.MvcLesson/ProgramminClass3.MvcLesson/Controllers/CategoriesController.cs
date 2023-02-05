using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Data.Migrations;
using ProgramminClass3.MvcLesson.Models;


namespace ProgramminClass3.MvcLesson.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List <Category> categories = _dbContext.Categories.ToList();

            return View(categories);
        }

        [HttpGet]       
        public IActionResult Create()
        {
            ViewBag.Categories = _dbContext.Categories.ToList();
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
            ViewBag.Categories = _dbContext.Categories.ToList();

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


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);

            

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCofirmed(int id)
        {
            var category = _dbContext.Categories.Find(id);

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
