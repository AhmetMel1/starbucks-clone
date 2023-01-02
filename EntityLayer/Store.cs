using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Store
    {

        public Store()
        {
            StoreOpeningHours = new List<StoreOpeningHour>();
        }

        [Key]
        public int StoreId { get; set; } //  PascalCase , camelCase, snake_case
        [StringLength(50)]
        public string StoreName { get; set; }
        [StringLength(50)]
        public string StoreLocation { get; set; }

        // Relationship with StoreOpeningHour
        public ICollection<StoreOpeningHour> StoreOpeningHours { get; set; }
        //relationship with storeproperty
        public ICollection<StoreProperty> StoreProperties { get; set; }
        //relationship with storefavorite
        public ICollection<StoreFavorite> StoreFavorites { get; set; }
        //relaionship with storeproduct 
        public ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
