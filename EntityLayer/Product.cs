using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        [StringLength(50)]
        public string productName { get; set; }
        [StringLength(50)]
        public string productLogoUrl { get; set; }
        [StringLength(200)]
        public string productDescription { get; set; }
        //Relationship with Category
        public int categoryId { get; set; } 
        public Category category { get; set; }
        //Relationship with ProductCustomization
        public ICollection<ProductCustomization> productCustomizations { get; set; }
        //Relationship with ProductSize
        public ICollection<ProductSize> productSizes { get; set; }

        //Relationship with Favorite
        public ICollection<Favorite>favorites{ get; set; }

    }
}
