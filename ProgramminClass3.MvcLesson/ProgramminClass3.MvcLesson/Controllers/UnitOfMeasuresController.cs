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
    }
}
