using ecommerce.Core.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() 
        {
            //Email
            RuleFor(temp => temp.Email).NotEmpty().
                WithMessage("Email is Required")
                .EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
