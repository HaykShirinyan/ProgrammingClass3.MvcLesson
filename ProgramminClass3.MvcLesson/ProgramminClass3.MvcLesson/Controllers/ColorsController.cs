using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class ColorsController : Controller
    {
        private ApplicationDbContext _dbContext;
        public ColorsController (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
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
           
                _dbContext.Colors.Add(color);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var product = _dbContext.Colors.Find(id);
            var color = _dbContext
                .Colors
                .FirstOrDefault(p => p.Id == id);

            return View(color);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Color color)
        {
     
                _dbContext.Colors.Update(color);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
        }
            //return View(product);
  
    }
}
