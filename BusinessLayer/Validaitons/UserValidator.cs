using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            //Rule for Name
            RuleFor(user => user.name).NotEmpty();
            RuleFor(user => user.name).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(user => user.name).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
            //Rule for Surname
            RuleFor(user => user.surname).NotEmpty();
            RuleFor(user => user.surname).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(user => user.surname).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
            //Rule for Password
            RuleFor(user => user.password).NotEmpty();
            RuleFor(user => user.password).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(user => user.password).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
            //Rule for PhoneNumber
            RuleFor(user => user.phoneNumber).NotEmpty();
            RuleFor(user => user.phoneNumber).MaximumLength(11).WithMessage("A maximum of 11 characters can be entered.");
            RuleFor(user => user.phoneNumber).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
        }  
    }
}
