using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class CustomizationValidator:AbstractValidator<Customization>
    {
        public CustomizationValidator() 
        {
            //Rule for CustomizationName
            RuleFor(customization => customization.customizationName).NotEmpty();
            RuleFor(customization => customization.customizationName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(customization => customization.customizationName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
        }
    }
}
