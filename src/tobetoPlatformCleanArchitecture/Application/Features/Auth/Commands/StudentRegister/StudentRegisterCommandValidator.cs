using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.StudentRegister;
public class StudentRegisterCommandValidator: AbstractValidator<StudentRegisterCommand>
{
    public StudentRegisterCommandValidator()
    {
        RuleFor(c => c.StudentForRegisterDto.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.StudentForRegisterDto.LastName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.StudentForRegisterDto.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.StudentForRegisterDto.Password).NotEmpty().MinimumLength(4);
    }
}
