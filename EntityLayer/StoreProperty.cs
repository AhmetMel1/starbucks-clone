using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class StoreProperty //kübra
    { 
        [Key]
        public int StorePropertyId { get; set; }
        public bool StorePropertyDeleted { get; set; }
        //relationship with property
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        //relationship with store
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}
