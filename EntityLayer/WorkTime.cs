using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class WorkTime
    {
        [Key]
        public int workTimeId { get; set; }
        public ICollection<StoreOpeningHour> StoreOpenings { get; set; }
        public int openingTime { get; set; }
        public int closingTime { get; set; }


    }
}
