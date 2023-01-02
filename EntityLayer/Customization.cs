﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Customization
    {
        [Key]
        public int customizationId { get; set; }
        [StringLength(50)]
        public string customizationName { get; set; }
        //Relationship with ProductCustomization
        public ICollection<ProductCustomization> productCustomizations { get; set; }
        //Relationship with Option
        public int optionId { get; set; }
        public Option option { get; set; }
    }
}