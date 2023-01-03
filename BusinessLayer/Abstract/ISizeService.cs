using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISizeService
    {
        void sizeInsert(Size size);
        void sizeUpdate(Size size);
        void sizeDelete(Size size);
        List<Size> sizeList();
        Size sizeGetById(int id);
        Size sizeGetByName(string name);
    }
}
