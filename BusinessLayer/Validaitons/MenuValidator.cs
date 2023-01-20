using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class MenuValidator : AbstractValidator<Menu>
    {
        public MenuValidator() 
        {
            //Rule for MenuName
            RuleFor(menu => menu.menuName).NotEmpty();
            RuleFor(menu => menu.menuName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(menu => menu.menuName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
        }  
    }
}
