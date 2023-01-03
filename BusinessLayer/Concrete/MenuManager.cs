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
    public class MenuManager : IMenuService
    {
        IMenuDal menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            this.menuDal = menuDal;
        }
        public void menuDelete(Menu menu)
        {
            menuDal.delete(menu);
        }

        public Menu MenuGetById(int id)
        {
            return menuDal.get(x => x.menuId == id);
        }

        public void menuInsert(Menu menu)
        {
            menuDal.insert(menu);
        }

        public List<Menu> menuList()
        {
            return menuDal.list();
        }

        public void menuUpdate(Menu menu)
        {
            menuDal.update(menu);
        }
    }
}
