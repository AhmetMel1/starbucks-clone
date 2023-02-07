using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Slider
    {
        [Key]
        public int sliderId { get; set; }
        [StringLength(50)]
        public string sliderName { get; set; }
        [StringLength(50)]
        public string sliderInformation { get; set; }
        [StringLength(200)]
        public string sliderImage { get; set; }
        public bool sliderDeleted { get; set; }
        [NotMapped]
        public IFormFile imgFile { get; set; }

    }
}
