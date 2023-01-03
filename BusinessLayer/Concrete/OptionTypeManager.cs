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
    public class OptionTypeManager : IOptionTypeService
    {
        IOptionTypeDal optionTypeDal;
        public OptionTypeManager(IOptionTypeDal optionTypeDal)
        {
            this.optionTypeDal = optionTypeDal;
        }
        public void optionTypeDelete(OptionType optionType)
        {
            optionTypeDal.delete(optionType);
        }

        public OptionType optionTypeGetById(int id)
        {
            return optionTypeDal.get(x => x.optionTypeId == id);
        }

        public OptionType optionTypeGetByName(string name)
        {
            return optionTypeDal.get(x => x.optionTypeName == name);
        }

        public void optionTypeInsert(OptionType optionType)
        {
            optionTypeDal.insert(optionType);
        }

        public List<OptionType> optionTypeList()
        {
            return optionTypeDal.list();
        }

        public void optionTypeUpdate(OptionType optionType)
        {
            optionTypeDal.update(optionType);
        }
    }
}
