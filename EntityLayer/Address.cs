using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Address
    {
        [Key]
        public int addressId { get; set; }
        [StringLength(50)]  
        public string province { get; set; }
        [StringLength(50)]
        public string district { get; set; }
        [StringLength(50)]
        public string neighbourhood { get; set; }
        [StringLength(50)]
        public string street { get; set; }
        [StringLength(10)]
        public string apartmentNumber { get; set; }
        //Relationship with User 
        public ICollection<User> users { get; set; }

    }
}
