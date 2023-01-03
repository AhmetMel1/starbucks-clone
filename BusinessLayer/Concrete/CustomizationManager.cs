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
    public class CustomizationManager : ICustomizationService
    {
        ICustomizationDal customizationDal;
        public CustomizationManager(ICustomizationDal customizationDal)
        {
            this.customizationDal = customizationDal;
        }
        public void customizationDelete(Customization customization)
        {
            customizationDal.delete(customization);
        }

        public Customization customizationGetById(int id)
        {
            return customizationDal.get(x => x.customizationId == id);
        }

        public Customization customizationGetByName(string name)
        {
            return customizationDal.get(x => x.customizationName == name);
        }

        public void customizationInsert(Customization customization)
        {
            customizationDal.insert(customization);
        }

        public List<Customization> customizationList()
        {
            return customizationDal.list();
        }

        public void customizationUpdate(Customization customization)
        {
            customizationDal.update(customization);
        }
    }
}
