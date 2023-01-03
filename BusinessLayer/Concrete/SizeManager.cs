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
    public class SizeManager : ISizeService
    {
        ISizeDal sizeDal;
        public SizeManager(ISizeDal sizeDal)
        {
            this.sizeDal = sizeDal;
        }
        public void sizeDelete(Size size)
        {
            sizeDal.delete(size);
        }

        public Size sizeGetById(int id)
        {
            return sizeDal.get(x => x.sizeId == id);
        }

        public void sizeInsert(Size size)
        {
            sizeDal.insert(size);
        }

        public List<Size> sizeList()
        {
            return sizeDal.list();
        }

        public void sizeUpdate(Size size)
        {
            sizeDal.update(size);
        }
    }
}
