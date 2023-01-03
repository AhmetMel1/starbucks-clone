using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStoreProductService
    {
        void StoreProductInsert(StoreProduct storeProduct);
        void StoreProductUpdate(StoreProduct storeProduct);
        void StoreProductDelete(StoreProduct storeProduct);
        List<StoreProduct> StoreProductsList();
        StoreProduct StoreProductGetById(int id);
    }
}
