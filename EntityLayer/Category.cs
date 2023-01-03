using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("categoryParent")]

        public int? categoryParentId { get; set; }
        public virtual Category categoryParent { get; set; }
        [InverseProperty("categoryParent")]
        public virtual ICollection<Category> categoryChildren { get; set; }
    }
}
