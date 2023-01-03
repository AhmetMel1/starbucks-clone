using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOptionTypeService
    {
        void optionTypeInsert(OptionType optionType);
        void optionTypeUpdate(OptionType optionType);
        void optionTypeDelete(OptionType optionType);
        List<OptionType> optionTypeList();
        OptionType optionTypeGetById(int id);
    }
}
