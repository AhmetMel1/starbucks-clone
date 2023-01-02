using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class StoreProduct
    {
        public int StoreProductId { get; set; }
        public int StockQuantity { get; set; }
        //relationship with product

        //relationship with store
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
