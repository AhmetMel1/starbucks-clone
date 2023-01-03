using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Size
    {
        [Key]
        public int sizeId { get; set; }
        [StringLength(50)]
        public string sizeName { get; set; } 
        //Relationship with ProductSize
        public virtual ICollection<ProductSize> productSizes { get; set; }

    }
}
