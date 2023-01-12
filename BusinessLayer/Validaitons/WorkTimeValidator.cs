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
        public WorkTimeValidator() {
            // rulefor openingtime
            RuleFor(workTime => workTime.openingTime).NotEmpty().WithMessage("Empty cannot be passed.");
            //rulefor closing time
            RuleFor(workTime => workTime.closingTime).NotEmpty().WithMessage("Empty cannot be passed.");
        }
    }
}
