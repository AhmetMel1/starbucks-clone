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
    public class ProductSizeManager : IProductSizeService
    {
        IProductSizeDal productSizeDal;
        public ProductSizeManager(IProductSizeDal productSizeDal)
        {
            this.productSizeDal = productSizeDal;
        }
        public void productSizeDelete(ProductSize productSize)
        {
            productSizeDal.delete(productSize);
        }

        public ProductSize productSizeGetById(int id)
        {
            return productSizeDal.get(x => x.productSizeId == id);
        }

        public void productSizeInsert(ProductSize productSize)
        {
            productSizeDal.insert(productSize);
        }

        public List<ProductSize> productSizeList()
        {
           return productSizeDal.list();
        }

        public void productSizeUpdate(ProductSize productSize)
        {
            productSizeDal.update(productSize);
        }
    }
}
