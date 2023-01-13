using EntityLayer;

namespace StarbucksProje.Models
{
    public class FavoriteUserProductModel
    {
        public Favorite favoriteModel { get; set; }
        public IEnumerable<User> userModel { get; set; }
        public IEnumerable<Product> productModel { get; set; }
    }
}
