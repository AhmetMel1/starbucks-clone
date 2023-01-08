using EntityLayer;

namespace StarbucksProje.Models
{
    public class StoreFavoriteModel
    {
        public StoreFavorite storeFavoriteModel { get; set; }
        public IEnumerable<Store> storeModel { get; set; }
        public IEnumerable<User> userModel { get; set; }
    }
}
