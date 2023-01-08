using EntityLayer;

namespace StarbucksProje.Models
{
    public class ProductCustomizationModel
    {
        public ProductCustomization productCustomizationModel { get; set; }
        public IEnumerable<Product> productModel { get; set; }
        public IEnumerable<Customization> customizationModel { get; set; }
    }
}
