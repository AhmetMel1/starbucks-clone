using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ProductCustomization
    {
        [Key]
        public int ProductCustomizationId { get; set; }
        //Relationship with Product
        public int productId { get; set; }
        public Product product { get; set; }
        //Relationship with Customization
        public int customizationId { get; set; }
        public Customization customization { get; set; }
    }
}
