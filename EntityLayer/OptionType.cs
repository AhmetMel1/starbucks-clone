using System;
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
        //Relationship with Option
        public ICollection<Option> options { get; set; }
    }
} 
