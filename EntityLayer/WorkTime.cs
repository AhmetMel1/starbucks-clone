using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class WorkTime //kübra
    {
        [Key]
        public int workTimeId { get; set; }
        public virtual ICollection<StoreOpeningHour> StoreOpenings { get; set; }
        public DateTime openingTime { get; set; }
        public DateTime closingTime { get; set; }
        public bool WorkTimeDeleted { get; set; }


    }
}
