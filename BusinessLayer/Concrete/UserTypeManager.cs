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
    public class UserTypeManager : IUserTypeService
    {
        IUserTypeDal userTypeDal;
        public UserTypeManager(IUserTypeDal userTypeDal)
        {
            this.userTypeDal = userTypeDal;
        }
        public void userTypeDelete(UserType userType)
        {
            userTypeDal.delete(userType);
        }

        public UserType UserTypeGetById(int id)
        {
            return userTypeDal.get(x => x.userTypeId == id);
        }

        public void userTypeInsert(UserType userType)
        {
            userTypeDal.insert(userType);
        }

        public List<UserType> userTypeList()
        {
            return userTypeDal.list();
        }

        public void userTypeUpdate(UserType userType)
        {
            userTypeDal.update(userType);
        }
    }
}
