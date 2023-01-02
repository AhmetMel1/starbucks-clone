using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public class ProductSize
    {
        [Key]
        public int productSizeId { get; set; }
        public int productSizePrice { get; set; }
        public int productSizeCapacity { get; set; }
        public int unitPrice { get; set; }

        //Relationship with Product
        public int productId { get; set; }
        public Product product { get; set; }
        //Relationship with Size
        public int sizeId { get; set; }
        public Size size { get; set; }

        //Relationship with Order
        public ICollection<Order> orders { get; set; }
    }
}
