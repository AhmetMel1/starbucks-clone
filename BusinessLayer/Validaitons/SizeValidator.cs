using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class SizeValidator:AbstractValidator<Size>
    {
        public SizeValidator()
        {
            //Rule for SizeName
            RuleFor(size => size.sizeName).NotEmpty();
            RuleFor(size => size.sizeName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(size => size.sizeName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
        }
    }
}
