using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserTypeService
    {
        void userTypeInsert(UserType userType);
        void userTypeUpdate(UserType userType);
        void userTypeDelete(UserType userType);
        List<UserType> userTypeList();
        UserType UserTypeGetById(int id);
    }
}
