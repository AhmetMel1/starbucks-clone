using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //Rule for ProductName
            RuleFor(product => product.productName).NotEmpty();
            RuleFor(product => product.productName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(product => product.productName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
            //Rule for ProductDescription
            RuleFor(product => product.productDescription).NotEmpty();
            RuleFor(product => product.productDescription).MaximumLength(200).WithMessage("A maximum of 200 characters can be entered.");
            RuleFor(product => product.productDescription).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
            //Rule for ProductLogoUrl
            RuleFor(product => product.imgFile).NotEmpty();
        }
    }
}
