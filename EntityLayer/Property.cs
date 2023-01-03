using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Property //kübra 
    {
        [Key]
        public int PropertyId { get; set; }
        [StringLength(50)]
        public string PropertyName { get; set; }
        public string PropertyMode { get; set; }
        //relationship with storeproperty
        public virtual ICollection<StoreProperty> StoreProperties { get; set; }
    }
}
