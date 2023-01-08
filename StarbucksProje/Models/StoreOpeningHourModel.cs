using EntityLayer;

namespace StarbucksProje.Models
{
    public class StoreOpeningHourModel
    {
        public StoreOpeningHour storeOpeningHourModel { get; set; }
        public IEnumerable<WorkTime> workTimeModel { get; set; }
        public IEnumerable<Store> storeModel { get; set; }


    }
}
