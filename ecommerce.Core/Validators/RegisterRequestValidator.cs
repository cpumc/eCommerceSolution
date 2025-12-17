using ecommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Core.Validators
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {

        public RegisterRequestValidator()
        {

            RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not correct format");
            RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("Person name is 1,required").Length(1, 50).WithMessage("Length should be 1 to 50");
            RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(temp => temp.Gender).IsInEnum().WithMessage("its outside the range");
        }           

    }
}
