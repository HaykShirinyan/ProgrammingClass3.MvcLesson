using ProgramminClass3.MvcLesson.Models;

namespace ProgramminClass3.MvcLesson.ViewModels
{
    public class ProductSizeListViewModel
    {
        public List<ProductSize> ProductSizes { get; set; }

        public List<Size> Sizes { get; set; }

        public int ProductId { get; set; }

        public int SizeId { get; set; }

    }
}
