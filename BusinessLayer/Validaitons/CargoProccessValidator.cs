using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class CargoProccessValidator : AbstractValidator<CargoProcess>
    {
        public CargoProccessValidator() 
        {
            //Rule for CargoStatus
            RuleFor(cargoProcess => cargoProcess.cargoStatus).NotEmpty();
            RuleFor(cargoProcess => cargoProcess.cargoStatus).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(cargoProcess => cargoProcess.cargoStatus).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for TrackingNumber
            RuleFor(cargoProcess => cargoProcess.trackingNumber).NotEmpty();
            RuleFor(cargoProcess => cargoProcess.trackingNumber).MaximumLength(50).WithMessage("A maximum of 13 characters can be entered.");
            RuleFor(cargoProcess => cargoProcess.trackingNumber).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");
        }
    }
}
