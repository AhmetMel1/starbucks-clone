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
    public class OptionManager : IOptionService
    {
        IOptionDal optionDal;
        public OptionManager(IOptionDal optionDal)
        {
            this.optionDal = optionDal;
        }
        public void optionDelete(Option option)
        {
            optionDal.delete(option);
        }

        public Option optionGetById(int id)
        {
            return optionDal.get(x => x.optionId == id);
        }

        public Option optionGetByName(string name)
        {
            return optionDal.get(x => x.optionName == name);
        }

        public void optionInsert(Option option)
        {
            optionDal.insert(option);
        }

        public List<Option> optionList()
        {
            return optionDal.list();
        }

        public void optionUpdate(Option option)
        {
            optionDal.update(option);
        }
    }
}
