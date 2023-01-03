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
    public class ProductCustomizationManager : IProductCustomizationService
    {
        IProductCustomizationDal productCustomizationDal;
        public ProductCustomizationManager(IProductCustomizationDal productCustomizationDal)
        {
            this.productCustomizationDal = productCustomizationDal;
        }
        public void productCustomizationDelete(ProductCustomization productCustomization)
        {
            productCustomizationDal.delete(productCustomization);
        }

        public ProductCustomization productCustomizationGetById(int id)
        {
            return productCustomizationDal.get(x => x.productCustomizationId == id);
        }

        public void productCustomizationInsert(ProductCustomization productCustomization)
        {
            productCustomizationDal.insert(productCustomization);
        }

        public List<ProductCustomization> productCustomizationList()
        {
            return productCustomizationDal.list();
        }

        public void productCustomizationUpdate(ProductCustomization productCustomization)
        {
            productCustomizationDal.update(productCustomization);
        }
    }
}
