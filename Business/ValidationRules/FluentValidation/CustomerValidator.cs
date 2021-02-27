using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage("Please, specify a Company Name");
            RuleFor(c => c.CompanyName).MinimumLength(5);
            RuleFor(c => c.Id).NotEqual(c => c.Id).WithMessage("Id number, must specify private for each customer");


        }
}   }
