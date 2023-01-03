using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductSizeService
    {
        void productSizeInsert(ProductSize productSize);
        void productSizeUpdate(ProductSize productSize);
        void productSizeDelete(ProductSize productSize);
        List<ProductSize> productSizeList();
        ProductSize productSizeGetById(int id);
    }
}
