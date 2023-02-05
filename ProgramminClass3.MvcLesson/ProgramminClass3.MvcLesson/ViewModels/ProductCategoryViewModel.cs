using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.ViewModels
{
    public class ProductCategoryListViewModel
    {
        public List<ProductCategory> ProductCategoies { get; set; }

        public List<Category> Categories { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}