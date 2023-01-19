using EntityLayer;

namespace StarbucksProje.Models
{
    public class UseraddressIdModel
    {
        public User userModel { get; set; }
        public IEnumerable<Address> addressModel { get; set; }
       

        
    }
}
