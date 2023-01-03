using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomizationService
    {
        void customizationInsert(Customization customization);
        void customizationUpdate(Customization customization);
        void customizationDelete(Customization customization);
        List<Customization> customizationList();
        Customization customizationGetById(int id);
    }
}
