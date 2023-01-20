using Microsoft.AspNetCore.Mvc;
using ProgramminClass3.MvcLesson.Data;

namespace ProgramminClass3.MvcLesson.Controllers
{
    public class UnitOfMeasureController1 : Controller
    {
        private ApplicationDbContext _dbContext;
        public UnitOfMeasureController1(ApplicationDbContext dbContext)

        { 
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var unitOfMeasure = _dbContext.UnitOfMeasures.ToList();
            return View(unitOfMeasure);
        }
    }
}
