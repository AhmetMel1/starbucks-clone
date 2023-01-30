using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AdminManager : IAdminService
	{
		IAdminDal adminDal;
		public AdminManager(IAdminDal adminDal)
		{
			this.adminDal = adminDal;
		}
		public void adminDelete(Admin admin)
		{
			adminDal.delete(admin);
		}

		public Admin adminGetById(int id)
		{
			return adminDal.get(x => x.adminId == id);
		}

        public Admin adminGetByMail(string mail)
        {
            return adminDal.get(x => x.adminMail == mail);
        }

        public void adminInsert(Admin admin)
		{
			adminDal.insert(admin);
		}

		public List<Admin> adminlist()
		{
			return adminDal.list();
		}

		public void adminUpdate(Admin admin)
		{
			adminDal.update(admin);
		}
	}
}
