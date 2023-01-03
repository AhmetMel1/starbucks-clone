using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        void productInsert(Product product);
        void productUpdate(Product product);
        void productDelete(Product product);
        List<Product> productList();
        Product productGetById(int id);
        Product productGetByName(string name);
    }
}
