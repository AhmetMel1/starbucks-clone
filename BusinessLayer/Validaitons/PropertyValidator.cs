﻿using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class PropertyValidator : AbstractValidator<Property>
    {
        public PropertyValidator()
        {
            // rulefor property name
            RuleFor(property => property.PropertyName).NotEmpty().WithMessage("Empty cannot be passed");
            RuleFor(property => property.PropertyName).MaximumLength(50).WithMessage("A maximum of 50 characters must be entered");
            RuleFor(property => property.PropertyName).MinimumLength(5).WithMessage("A minimum of 5 characters must be entered");

            //rulefor property mode
            RuleFor(property => property.PropertyMode).NotEmpty().WithMessage("Property mode Empty cannot be passed ");

        }
    }
}