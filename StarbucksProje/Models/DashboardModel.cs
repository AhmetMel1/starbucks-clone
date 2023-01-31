using EntityLayer;

namespace StarbucksProje.Models
{
    public class DashboardModel
    {
        public IEnumerable<Admin> adminModel { get; set; }
        public IEnumerable<User> userModel { get; set; }
        public IEnumerable<Order> orderModel { get; set; }
    }
}
