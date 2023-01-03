using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStoreOpeningHourService
    {
        void StoreOpeningHourInsert(StoreOpeningHour storeOpeningHour);
        void StoreOpeningHourUpdate(StoreOpeningHour storeOpeningHour);
        void StoreOpeningHourDelete(StoreOpeningHour storeOpeningHour);
        List<StoreOpeningHour> StoreOpeningHourList();
        StoreOpeningHour StoreOpeningHourGetById(int id);

    }
}
