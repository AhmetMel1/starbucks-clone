using EntityLayer;

namespace StarbucksProje.Models
{
    public class MenuParentMenuIdModel
    {
        public Menu menuModel { get; set; }
        public IEnumerable<Menu> menuParentModel { get; set; }
      
    }
}
