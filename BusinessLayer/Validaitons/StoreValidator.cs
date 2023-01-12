using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class StoreValidator : AbstractValidator<Store>
    {
        public StoreValidator()
        {
            //rulefor sore name
            RuleFor(store => store.StoreName).NotEmpty().WithMessage("Empty cannot be passed.");
            RuleFor(store => store.StoreName).NotEmpty().MaximumLength(50).WithMessage("A maximum of 50 characters must be entered.");
            RuleFor(store => store.StoreName).NotEmpty().MinimumLength(5).WithMessage("A minimum of 5 characters must be entered.");
            // rulefor store location
            RuleFor(store => store.StoreLocation).NotEmpty().WithMessage("Empty cannot be passed.");
            RuleFor(store => store.StoreLocation).NotEmpty().MaximumLength(50).WithMessage("A maximum of 50 characters must be entered.");
            RuleFor(store => store.StoreLocation).NotEmpty().MinimumLength(5).WithMessage("A minimum of 5 characters must be entered.");

        }
    }
}
