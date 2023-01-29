using ProgramminClass3.MvcLessons.Models;

namespace ProgramminClass3.MvcLesson.Models
{
    public class ProducCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}