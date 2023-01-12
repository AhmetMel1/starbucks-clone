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
            RuleFor(optionType => optionType.optionTypeName).NotEmpty();
            RuleFor(optionType => optionType.optionTypeName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(optionType => optionType.optionTypeName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
        }    
    }
}
