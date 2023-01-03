using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMenuServis
    {
        void menuInsert(Menu menu);
        void menuUpdate(Menu menu);
        void menuDelete(Menu menu);
        List<Menu> menuList();
        Menu MenuGetById(int id);


    }
}
