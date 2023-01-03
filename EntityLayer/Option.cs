using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Option
    {
        [Key]
        public int optionId { get; set; }
        [StringLength(50)]
        public string optionName { get; set; }
        public int optionUnitPrice { get; set; }
        public bool optionDeleted { get; set; }
        //Relationship with OptionType
        public int optionTypeId { get; set; }
        public virtual OptionType optionType { get; set; }
        //Relationship with Customization
        public virtual ICollection<Customization> customizations { get; set; }
        //Kendine çok olucak
        public int? parentOptionId { get; set; }
        public virtual Option option { get; set; }
    }
}
