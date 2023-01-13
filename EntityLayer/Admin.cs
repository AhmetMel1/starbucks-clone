﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Admin
    {
        [Key]   
        public int adminId { get; set; }
        [StringLength(50)]  
        public string adminName { get; set; }
		[StringLength(50)]
        public string adminEmail { get; set; }
        [StringLength(50)]
        public string adminPassword { get; set; }
		[StringLength(150)]
        public string adminProfilPhoto { get; set; }
        [StringLength(50)]
        public string adminType { get; set; }
		public bool adminDeleted { get; set; }

    }
}
