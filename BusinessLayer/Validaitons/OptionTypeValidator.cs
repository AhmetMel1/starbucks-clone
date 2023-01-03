using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class OptionTypeValidator:AbstractValidator<OptionType>
    {
        public OptionTypeValidator() 
        {
            //Rule for OptionName
            RuleFor(optionType => optionType.optionTypeName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(optionType => optionType.optionTypeName).MaximumLength(50).WithMessage("Maximum 50 karakter girilebilir.");
            RuleFor(optionType => optionType.optionTypeName).MinimumLength(2).WithMessage("Minimum 2 karakter girilmedilir.");
        }    
    }
}
