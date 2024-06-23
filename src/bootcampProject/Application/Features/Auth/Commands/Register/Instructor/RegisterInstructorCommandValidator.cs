using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register.Instructor;

public class RegisterInstructorCommandValidator : AbstractValidator<RegisterInstructorCommand>
{
    public RegisterInstructorCommandValidator()
    {
        RuleFor(c => c.InstructorForRegisterDto.Email).NotEmpty().EmailAddress();
    }
}
