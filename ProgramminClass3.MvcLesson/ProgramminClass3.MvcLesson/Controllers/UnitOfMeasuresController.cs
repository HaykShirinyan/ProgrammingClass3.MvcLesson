using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;

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
            var unitOfMeasure = _dbContext.UnitOfMeasures.ToList();
            return View(unitOfMeasure);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _dbContext.UnitOfMeasures.Add(unitOfMeasure);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();

            return View(unitOfMeasure);
        }
    }
}
