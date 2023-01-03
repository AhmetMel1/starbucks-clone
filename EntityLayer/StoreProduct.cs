using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class StoreProduct //kübra
    {
        [Key]
        public int StoreProductId { get; set; }
        public int StockQuantity { get; set; }
        //relationship with product
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }

        //relationship with store
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}
