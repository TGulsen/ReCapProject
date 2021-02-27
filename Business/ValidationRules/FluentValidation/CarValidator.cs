using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotNull();
        
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            // BMW grubundaki araçların günlük fiyatları < 75
            RuleFor(c => c.DailyPrice).GreaterThan(75).When(c => c.BrandId == 2);
            
            

        }
    }
}
