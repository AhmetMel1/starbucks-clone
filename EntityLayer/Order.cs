using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public bool paymentType { get; set; }       
        public DateTime orderDate { get; set; }
        public int orderQuantity { get; set; }
        public bool orderStatus { get; set; } 
        public DateTime cardAddedDate { get; set; }
        public bool orderDeleted { get; set; }

        //Relationship with Product size
        public  int productSizeId  { get; set; }
        public virtual ProductSize productSize { get; set; }
        //Relationship with CargoProcces 
        public  int cargoProccessId { get; set; }
        public virtual CargoProcess cargoProcess { get; set; }
        //Relationship with user  
        public  int userId { get; set; }
        public virtual User user { get; set; }


    }
}
