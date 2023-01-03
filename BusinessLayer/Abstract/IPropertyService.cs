using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IPropertyService
    {
        void PropertyInsert(Property property);
        void PropertyUpdate(Property property);
        void PropertyDelete(Property property);
        List<Property> PropertyList();
        Property PropertyGetById(int id);
    }
}
