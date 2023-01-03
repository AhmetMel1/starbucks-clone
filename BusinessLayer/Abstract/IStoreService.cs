using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStoreService
    {
        void StoreInsert(Store store);
        void StoreUpdate(Store store);
        void StoreDelete(Store store);
        List<Store> storeList();
        Store StorestoreGetById(int id);
    }
}
