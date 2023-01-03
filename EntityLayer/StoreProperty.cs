using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class StoreProperty
    {
        [Key]
        public int StorePropertyId { get; set; }
        //relationship with property
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        //relationship with store
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
