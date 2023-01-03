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
        public bool categoryDeleted { get; set; }
        //Relationship with Product
        public virtual ICollection<Product> products { get; set; } 
        //Kendine çok olucak
        public int? parentCategoryId { get; set; }
        public virtual Category category { get; set; }
    }
}
