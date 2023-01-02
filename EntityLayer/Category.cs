using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [StringLength(200)]
        public string categoryLogoUrl { get; set; }
        //Relationship with Product
        public ICollection<Product> products { get; set; } 
        //Kendine çok olucak
        public int? parentCategoryId { get; set; }
        public Category category { get; set; }
    }
}
