using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserType
    {
        [Key]
        public int userTypeId { get; set; }
        [StringLength(50)] 
        public string userTypeName { get; set; }
        //Relationship with user 
        public ICollection<User> users { get; set; }
    }
}
