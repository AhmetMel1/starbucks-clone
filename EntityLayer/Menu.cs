using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int menuName { get; set; }

        //KENDİNE ÇOK OLACAK 
       
    }
}
