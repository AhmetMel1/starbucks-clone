using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StorePropertyManager : IStorePropertyService
    {
       IStorePropertyDal storePropertyDal;
        public StorePropertyManager(IStorePropertyDal storePropertyDal)
        {
          this.storePropertyDal = storePropertyDal;
        }
        public void StorePropertyDelete(StoreProperty storeProperty)
        {
            storePropertyDal.delete(storeProperty);
        }

        public StoreProperty StorePropertyGetById(int id)
        {
            return storePropertyDal.get(x => x.StorePropertyId == id);
        }

        public void StorePropertyInsert(StoreProperty storeProperty)
        {
           storePropertyDal.insert(storeProperty);
        }

        public List<StoreProperty> StorePropertyList()
        {
            return storePropertyDal.list();
        }

        public void StorePropertyUpdate(StoreProperty storeProperty)
        {
            storePropertyDal.update(storeProperty);
        }
    }
}
