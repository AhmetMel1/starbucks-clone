using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
	public class Admin
	{
		[Key]
		public int adminId { get; set; }
		[StringLength(30)]
		public string adminFirstName { get; set; }
		[StringLength(30)]
		public string adminLastName { get; set; }
		[StringLength(50)]
		public string adminMail { get; set; }
		[StringLength(20)]
		public string adminPassword { get; set; }
		[StringLength(20)]
		public string adminType { get; set; }
		public DateTime adminBirthday { get; set; }
		[StringLength(100)]
		public string adminImgUrl { get; set; }
        public bool adminGender { get; set; }
        public bool adminDeleted { get; set; }
		[NotMapped]
		public IFormFile imgFile { get; set; }
	}
}
