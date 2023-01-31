using ProgramminClass3.MvcLesson.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgramminClass3.MvcLesson.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public Product Product { get; set; }

        public List<ProductType> ProductTypes { get; set; }

        public List<UnitOfMeasure> UnitOfMeasures { get; set; }
    }
}
