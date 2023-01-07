using EntityLayer;

namespace StarbucksProje.Models
{
    public class CustomizationOptionModel
    {
        public Customization customizationModel { get; set; }
        public IEnumerable<Option> optionModel { get; set; }
    }
}
