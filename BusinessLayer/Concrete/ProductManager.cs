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
    public class ProductManager : IProductService
    {
        IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }
        public void productDelete(Product product)
        {
            productDal.delete(product);
        }

        public Product productGetById(int id)
        {
            return productDal.get(x => x.productId == id);
        }

        public Product productGetByName(string name)
        {
            return productDal.get(x => x.productName == name);
        }

        public void productInsert(Product product)
        {
            productDal.insert(product);
        }

        public List<Product> productList()
        {
           return productDal.list();
        }

        public void productUpdate(Product product)
        {
            productDal.update(product);
        }
    }
}
