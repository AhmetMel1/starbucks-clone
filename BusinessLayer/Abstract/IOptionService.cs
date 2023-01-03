using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOptionService
    {
        void optionInsert(Option option);
        void optionUpdate(Option option);
        void optionDelete(Option option);
        List<Option> optionList();
        Option optionGetById(int id);
    }
}
