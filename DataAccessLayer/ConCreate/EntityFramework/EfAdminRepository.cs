using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConCreate.EntityFramework
{
    public class EfAdminRepository:GenericRepository<Admin>,IAdminDal
    {
    }
}
