using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() 
        {
            //Rule for orderQuantity
            RuleFor(order => order.orderQuantity).NotEmpty();
            //Rule for OrderDate
            RuleFor(order => order.orderDate).Must(BeAValidDate).NotEmpty();
            //Rule for CardAddedDate
            RuleFor(order => order.cardAddedDate).Must(BeAValidDate).NotEmpty();
            bool BeAValidDate(DateTime date)
            {
                return !date.Equals(default(DateTime));
            }
        } 
    }
}
