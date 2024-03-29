﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class Favorite
    {
        [Key]
        public int favoriteId { get; set; }
        public DateTime uploadDate { get; set; }
        public bool favoriteDeleted { get; set; }

        //Relationship with user  
        public  int userId { get; set; }
        public virtual User user { get; set; }

        //Relationship with product

        public  int productId { get; set; }
        public  virtual Product product { get; set; }
    }
}
