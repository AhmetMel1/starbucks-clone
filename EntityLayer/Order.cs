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
        public byte paymentType { get; set; }
        [StringLength(50)] 
        public string orderDate { get; set; }
        public int orderQuantity { get; set; }
        public byte orderStatus { get; set; }
        [StringLength(50)]
        public string cardAddedDate { get; set; }

        //Relationship with Product size
        public int productSizeId  { get; set; }
        public ProductSize productSize { get; set; }
        //Relationship with CargoProcces 
        public int cargoId { get; set; }
        public CargoProcess cargoProcess { get; set; }
        //Relationship with user  
        public int userId { get; set; }
        public User user { get; set; }


    }
}
