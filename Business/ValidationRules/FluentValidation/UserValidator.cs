using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).Must((u, LastName) => LastName != u.FirstName);
            RuleFor(u => u.Password).NotEmpty().NotEqual(u=>u.Password);
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.Email).EmailAddress();

        }
    }
}
