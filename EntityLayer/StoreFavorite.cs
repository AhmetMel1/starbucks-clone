using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class StoreFavorite
    {
        public int StoreFavoriteId { get; set; }
        //relationship with store
        public int StoreId { get; set; }
        public Store Store { get; set; }
        // relationship with user

    }
}
