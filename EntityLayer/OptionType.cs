﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class OptionType
    {
        [Key]
        public int optionTypeId { get; set; }
        [StringLength(50)]
        public string optionTypeName { get; set; }
        public bool optionTypeDeleted { get; set; }
        //Relationship with Option
        public virtual ICollection<Option> options { get; set; }
    }
} 
