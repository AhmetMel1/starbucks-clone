using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserServis
    {
        void userInsert(User user);
        void userDelete(User user);
        void userUpdate(User user);
        List<User> userList();
        User UserGetById(int id);
        User UserGetByName(string name);

    }
}
