using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;
using ProgramminClass3.MvcLesson.Models;


namespace ProgramminClass3.MvcLesson.Controllers
{
    public class UnitOfMeasuresController : Controller
    {
        private ApplicationDbContext _dbContext;

        public UnitOfMeasuresController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var unitOfMeasures = _dbContext.UnitOfMeasures.ToList();
            
            return View(unitOfMeasures);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _dbContext.UnitOfMeasures.Add(unitOfMeasure);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(unitOfMeasure);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var unitOfMeasure = _dbContext.UnitOfMeasures.Find(id);

            return View(unitOfMeasure);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _dbContext.UnitOfMeasures.Update(unitOfMeasure);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(unitOfMeasure);
        }
    }
}
