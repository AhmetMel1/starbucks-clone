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
    public class StoreProductManager : IStoreProductService
    {
        IStoreProductDal storeProductDal;
        public StoreProductManager(IStoreProductDal storeProductDal)
        {
            this.storeProductDal = storeProductDal;
        }
        public void StoreProductDelete(StoreProduct storeProduct)
        {
            storeProductDal.delete(storeProduct);
        }

        public StoreProduct StoreProductGetById(int id)
        {
            return storeProductDal.get(x => x.StoreProductId == id);
        }

        public void StoreProductInsert(StoreProduct storeProduct)
        {
           storeProductDal.insert(storeProduct);
        }

        public List<StoreProduct> StoreProductsList()
        {
            return storeProductDal.list();
        }

        public void StoreProductUpdate(StoreProduct storeProduct)
        {
            storeProductDal.update(storeProduct);
        }
    }
}
