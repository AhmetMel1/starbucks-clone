using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class ProductSizeValidator:AbstractValidator<ProductSize>
    {
        public ProductSizeValidator()
        {
            //Rule for ProductSizePrice
            RuleFor(productSize => productSize.productSizePrice).NotEmpty();
            //Rule for ProductSizeCapacity
            RuleFor(productSize => productSize.productSizeCapacity).NotEmpty();
            //Rule for UnitPrice
            RuleFor(productSize => productSize.unitPrice).NotEmpty();
        }
    }
}
