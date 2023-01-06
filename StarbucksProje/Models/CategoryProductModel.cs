using EntityLayer;

namespace StarbucksProje.Models
{
    public class CategoryProductModel
    {
        public Product productModel { get; set; }
        public IEnumerable<Category> categoryModel { get; set; }
    }
}
