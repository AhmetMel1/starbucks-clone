using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Menu
    {
        [Key]
        public int menuId { get; set; }
        [StringLength(50)] 
        public string menuName { get; set; }
        public bool menuDeleted { get; set; }

       
        [ForeignKey("menuParent")]

        public int? menuParentId { get; set; }
        public virtual Menu menuParent { get; set; }
        [InverseProperty("menuParent")]
        public virtual ICollection<Menu> menuChildren { get; set; }

    }
}
 