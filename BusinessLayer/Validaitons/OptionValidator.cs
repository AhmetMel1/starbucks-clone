using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class OptionValidator:AbstractValidator<Option>
    {
        public OptionValidator() 
        {
            //Rule for OptionName
            RuleFor(option => option.optionName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(option => option.optionName).MaximumLength(50).WithMessage("Maximum 50 karakter girilebilir.");
            RuleFor(option => option.optionName).MinimumLength(2).WithMessage("Minimum 2 karakter girilmedilir.");
            //Rule for OptionUnitPrice
            RuleFor(option => option.optionUnitPrice).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}
