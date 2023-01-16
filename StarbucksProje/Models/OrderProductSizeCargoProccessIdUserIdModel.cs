using EntityLayer;

namespace StarbucksProje.Models
{
    public class OrderProductSizeCargoProccessIdUserIdModel
    {
        public Order orderModel { get; set; }
        public IEnumerable<User> userModel { get; set; }
        public IEnumerable<ProductSize> productSizeModel { get; set; }
        public IEnumerable<CargoProcess> cargoProcessesModel { get; set; }
    }
}
