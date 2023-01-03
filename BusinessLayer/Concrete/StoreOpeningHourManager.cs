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
   public class StoreOpeningHourManager : IStoreOpeningHourService
    {
        IStoreOpeningHourDal storeOpeningHourDal;
        public StoreOpeningHourManager(IStoreOpeningHourDal storeOpeningHourDal)
        {
            this.storeOpeningHourDal = storeOpeningHourDal;
        }

        public void StoreOpeningHourDelete(StoreOpeningHour storeOpeningHour)
        {
            storeOpeningHourDal.delete(storeOpeningHour);
        }

        public StoreOpeningHour StoreOpeningHourGetById(int id)
        {
            return storeOpeningHourDal.get(x => x.storeOpeningHourId== id);
        }

        public void StoreOpeningHourInsert(StoreOpeningHour storeOpeningHour)
        {
            storeOpeningHourDal.insert(storeOpeningHour);
        }

        public List<StoreOpeningHour> StoreOpeningHourList()
        {
           return storeOpeningHourDal.list();
        }

        public void StoreOpeningHourUpdate(StoreOpeningHour storeOpeningHour)
        {
           storeOpeningHourDal.update(storeOpeningHour);
        }
    }
}
