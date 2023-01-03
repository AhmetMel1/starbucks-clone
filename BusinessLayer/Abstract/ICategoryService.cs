using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void categoryInsert(Category category);
        void categoryUpdate(Category category);
        void categoryDelete(Category category);
        List<Category> categoryList();
        Category categoryGetById(int id);
    }
}
