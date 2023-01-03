using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductCustomizationService
    {
        void productCustomizationInsert(ProductCustomization productCustomization);
        void productCustomizationUpdate(ProductCustomization productCustomization);
        void productCustomizationDelete(ProductCustomization productCustomization);
        List<ProductCustomization> productCustomizationList();
        ProductCustomization productCustomizationGetById(int id);
    }
}
