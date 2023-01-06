using EntityLayer;

namespace StarbucksProje.Models
{
    public class ProductSizeModel
    {
        public ProductSize productSizeModel { get; set; }
        public IEnumerable<Product> productModel { get; set; }
        public IEnumerable<Size> sizeModel { get; set; }
    }
}
