using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class StoreOpeningHour
    {
        [Key]
        public int storeOpeningHourId { get; set; }

        //Relationship with store
        public int StoreId { get; set; }
        public Store Store { get; set; }

        //relationship WorkTime
        public int workTimeId { get; set; }

        public WorkTime workTime { get; set; }

    }
}
