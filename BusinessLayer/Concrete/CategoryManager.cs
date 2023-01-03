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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }
        public void categoryDelete(Category category)
        {
            categoryDal.delete(category);
        }

        public Category categoryGetById(int id)
        {
            return categoryDal.get(x => x.categoryId == id);
        }

        public void categoryInsert(Category category)
        {
            categoryDal.insert(category);
        }

        public List<Category> categoryList()
        {
            return categoryDal.list();
        }

        public void categoryUpdate(Category category)
        {
            categoryDal.update(category);
        }
    }
}
