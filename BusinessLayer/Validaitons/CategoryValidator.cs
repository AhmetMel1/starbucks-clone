using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            //Rule for CategoryName
            RuleFor(category => category.categoryName).NotEmpty();
            RuleFor(category => category.categoryName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(category => category.categoryName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
        }
    }
}
