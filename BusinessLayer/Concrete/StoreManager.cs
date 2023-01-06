using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StoreManager : IStoreService
    {
        IStoreDal storeDal;
        public StoreManager(IStoreDal storeDal)
        {
           this.storeDal = storeDal;
        }

        public void StoreDelete(Store store)
        {
            storeDal.delete(store);
        }

        public void  StoreInsert(Store store)
        {
            storeDal.insert(store);
        }

        public List<Store> storeList()
        {
            return storeDal.list();
        }
        public void StoreUpdate(Store store)
        {
            storeDal.update(store);
        }

        public Store StorestoreGetById(int id)
        {
            return storeDal.get(x => x.StoreId == id);
        }

        public void StoreInsert(global::StarbucksProje.Controllers.StoreConttoller store)
        {
            throw new NotImplementedException();
        }

        public void StoreInsert(global::StarbucksProje.Controllers.StoreConttoller store)
        {
            throw new NotImplementedException();
        }
    }
}
