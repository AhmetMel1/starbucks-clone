using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class AddressValidator: AbstractValidator<Address>
    {
        public AddressValidator() 
        {
            //Rule for City
            RuleFor(address => address.city).NotEmpty();
            RuleFor(address => address.city).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(address => address.city).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for District
            RuleFor(address => address.district).NotEmpty();
            RuleFor(address => address.district).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(address => address.district).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for Neighbourhood
            RuleFor(address => address.neighbourhood).NotEmpty();
            RuleFor(address => address.neighbourhood).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(address => address.neighbourhood).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for Street
            RuleFor(address => address.street).NotEmpty();
            RuleFor(address => address.street).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(address => address.street).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for ApartmentNumber
            RuleFor(address => address.apartmentNumber).NotEmpty();
            RuleFor(address => address.apartmentNumber).MaximumLength(10).WithMessage("A maximum of 10 characters can be entered.");
            RuleFor(address => address.apartmentNumber).MinimumLength(1).WithMessage("A minimum of 1 characters must be entered.");

            //Rule for CircleNumber
            RuleFor(address => address.circleNumber).NotEmpty();
            RuleFor(address => address.circleNumber).MaximumLength(10).WithMessage("A maximum of 10 characters can be entered.");
            RuleFor(address => address.circleNumber).MinimumLength(1).WithMessage("A minimum of 1 characters must be entered.");


        }
    }
}
