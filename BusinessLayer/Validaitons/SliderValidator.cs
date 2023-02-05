using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class SliderValidator : AbstractValidator<Slider>
    {
        public SliderValidator()
        {
            //Rule for sliderName
            RuleFor(slider => slider.sliderName).NotEmpty();
            RuleFor(slider => slider.sliderName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(slider => slider.sliderName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for sliderInformation
            RuleFor(slider => slider.sliderName).NotEmpty();
            RuleFor(slider => slider.sliderName).MaximumLength(50).WithMessage("A maximum of 50 characters can be entered.");
            RuleFor(slider => slider.sliderName).MinimumLength(2).WithMessage("A minimum of 2 characters must be entered.");

            //Rule for sliderImage
            RuleFor(slider => slider.sliderImage).NotEmpty();
        }
    }
}
