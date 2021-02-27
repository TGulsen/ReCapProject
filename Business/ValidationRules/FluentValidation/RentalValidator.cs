using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CustomerId).NotEqual(r => r.CustomerId);
            RuleFor(r => r.CarId).NotEmpty().NotEqual(r=>r.CarId);
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.Id).NotEqual(r => r.Id);
            RuleFor(r => r.ReturnDate).NotNull();


        }
    }
}
