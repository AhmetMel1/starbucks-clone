using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class WorkTimeValidator:AbstractValidator<WorkTime>
    {
        public WorkTimeValidator()
        {
            //Rule for OpeningTime
            RuleFor(WorkTime => WorkTime.openingTime).Must(BeAValidDate).NotEmpty();
            //Rule for ClosingTime
            RuleFor(WorkTime => WorkTime.closingTime).Must(BeAValidDate).NotEmpty();

            bool BeAValidDate(DateTime date)
            {
                return !date.Equals(default(DateTime));
            }
        }
    }
}
