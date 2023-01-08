using EntityLayer;

namespace StarbucksProje.Models
{
    public class StoreProductModel
    {
        public StoreProduct storeProductModel { get; set; }
        public IEnumerable<Product> productModel { get; set; }
        public IEnumerable<Store> storeModel { get; set; }
    }
}
