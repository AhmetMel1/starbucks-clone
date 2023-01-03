using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConCreate.EntityFramework
{
  public class EfPropertyRepository:GenericRepository<Property>,IPropertyDal
    {
    }
}
