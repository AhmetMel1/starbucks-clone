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
  public class PropertyManager : IPropertyService
    {
        IPropertyDal propertyDal;
        public PropertyManager(IPropertyDal propertyDal)
        {
            this.propertyDal = propertyDal;
        }

        public void PropertyDelete(Property property)
        {
            propertyDal.delete(property);
        }

        public Property PropertyGetById(int id)
        {
            return propertyDal.get(x => x.PropertyId == id);
        }

        public void PropertyInsert(Property property)
        {
            propertyDal.insert(property);
        }

        public List<Property> PropertyList()
        {
           return propertyDal.list();
        }

        public void PropertyUpdate(Property property)
        {
            propertyDal.update(property);
        }
    }
}
