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
            RuleFor(option => option.optionName).NotEmpty();
            RuleFor(option => option.optionName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(option => option.optionName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
            //Rule for OptionUnitPrice
            RuleFor(option => option.optionUnitPrice).NotEmpty();
        }
    }
}
