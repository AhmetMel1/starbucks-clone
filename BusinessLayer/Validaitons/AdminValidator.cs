using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            //Rule for adminFirstName
            RuleFor(admin => admin.adminFirstName).NotEmpty();
            RuleFor(admin => admin.adminFirstName).MaximumLength(30).WithMessage("A maximum of 30 characters can be entered.");
            RuleFor(admin => admin.adminFirstName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for adminLastName
            RuleFor(admin => admin.adminLastName).NotEmpty();
            RuleFor(admin => admin.adminLastName).MaximumLength(30).WithMessage("A maximum of 30 characters can be entered.");
            RuleFor(admin => admin.adminLastName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");


            //Rule for adminMail
            RuleFor(admin => admin.adminMail).NotEmpty();
            RuleFor(admin => admin.adminMail).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(admin => admin.adminMail).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for adminPassword
            RuleFor(admin => admin.adminPassword).NotEmpty();
            RuleFor(admin => admin.adminPassword).MaximumLength(20).WithMessage("A maximum of 20 characters can be entered.");
            RuleFor(admin => admin.adminPassword).MinimumLength(4).WithMessage("A minimum of 4 characters must be entered.");

            //Rule for adminImgUrl
            RuleFor(admin => admin.imgFile).NotEmpty();

            //Rule for Birthday
            RuleFor(admin => admin.adminBirthday).Must(BeAValidDate).NotEmpty();
            bool BeAValidDate(DateTime date)
            {
                return !date.Equals(default(DateTime));
            }
        }
    }
}
