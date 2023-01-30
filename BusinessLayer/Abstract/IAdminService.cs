using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IAdminService
	{
		void adminInsert(Admin admin);
		void adminDelete(Admin admin);
		void adminUpdate(Admin admin);
		List<Admin> adminlist();
		Admin adminGetById(int id);
		Admin adminGetByMail(string mail);
	}
}
