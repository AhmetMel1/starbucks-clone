using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class FavoriteValidator: AbstractValidator<Favorite>
    {
        public FavoriteValidator()
        {
            //Rule for UploadDate
           RuleFor(favorite => favorite.uploadDate).Must(BeAValidDate).NotEmpty();

            bool BeAValidDate(DateTime date)
            {
                return !date.Equals(default(DateTime));
            }
        }
    }
}
