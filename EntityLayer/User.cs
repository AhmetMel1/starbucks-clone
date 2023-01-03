using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [StringLength(50)]
        public string userName { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string surname { get; set; }
        [StringLength(50)]  
        public string password { get; set; }
        [StringLength(11)]
        public string phoneNumber { get; set; }

        public bool userDeleted { get; set; }
        public DateTime birthday { get; set; }
        //Relationship with Address
        public  int addressId { get; set; }
        public virtual Address address { get; set; }
        //Relationship with userType
        public  int userTypeId { get; set; }
        public virtual UserType userType { get; set; }
        //Relationship with order
        public virtual ICollection<Order> orders { get; set; }

        //Relationship with favorite 
        public virtual ICollection<Favorite> favorites { get; set; }

       
    }
}
