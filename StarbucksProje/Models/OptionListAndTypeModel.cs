using EntityLayer;

namespace StarbucksProje.Models
{
    public class OptionListAndTypeModel
    {
        public Option optionModel { get; set; }
        public IEnumerable<Option> optionListModel { get; set; }
        public IEnumerable<OptionType> optionTypeModel { get; set; }
    }
}
