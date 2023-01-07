using EntityLayer;

namespace StarbucksProje.Models
{
    public class StorePropertyModel
    {
        public StoreProperty storePropertyModel { get; set; }
        public IEnumerable<Property> propertyModel { get; set; }
        public IEnumerable<Store> storeModel { get; set; }
    }
}
