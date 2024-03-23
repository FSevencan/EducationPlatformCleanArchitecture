using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.StudentRegister;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.InstructorRegister;
public class InstructorRegisterCommandValidator : AbstractValidator<InstructorRegisterCommand>
{
    public InstructorRegisterCommandValidator()
    {
        RuleFor(c => c.InstructorForRegisterDto.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.InstructorForRegisterDto.LastName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.InstructorForRegisterDto.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.InstructorForRegisterDto.Password).NotEmpty().MinimumLength(4);
    }
}


