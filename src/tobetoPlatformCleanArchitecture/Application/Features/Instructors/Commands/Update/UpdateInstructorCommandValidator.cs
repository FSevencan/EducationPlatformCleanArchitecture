using FluentValidation;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommandValidator : AbstractValidator<UpdateInstructorCommand>
{
    public UpdateInstructorCommandValidator()
    {
        RuleFor(c => c.UpdateInstructorDto.Id).NotEmpty();
        RuleFor(c => c.UpdateInstructorDto.FirstName).NotEmpty();
        RuleFor(c => c.UpdateInstructorDto.LastName).NotEmpty();
        RuleFor(c => c.UpdateInstructorDto.Email).NotEmpty();
       
    }
}