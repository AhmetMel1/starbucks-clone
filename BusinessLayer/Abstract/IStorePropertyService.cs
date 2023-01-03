using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IStorePropertyService
    {
        void StorePropertyInsert(StoreProperty storeProperty);
        void StorePropertyUpdate(StoreProperty storeProperty);
        void StorePropertyDelete(StoreProperty storeProperty);
        List<StoreProperty> StorePropertyList();
        StoreProperty StorePropertyGetById(int id);
    }
}
