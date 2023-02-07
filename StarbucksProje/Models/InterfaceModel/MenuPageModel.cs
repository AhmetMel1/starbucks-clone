using EntityLayer;

namespace StarbucksProje.Models.InterfaceModel
{
    public class MenuPageModel
    {
        public IEnumerable<Category> categoryModel { get; set; }
        public IEnumerable<ProductSize> productSizeModel { get; set; }
    }
}
