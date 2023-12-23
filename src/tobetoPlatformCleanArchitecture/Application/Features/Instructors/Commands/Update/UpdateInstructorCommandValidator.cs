using FluentValidation;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommandValidator : AbstractValidator<UpdateInstructorCommand>
{
    public UpdateInstructorCommandValidator()
    {
        RuleFor(c => c.InstructorDto.Id).NotEmpty();
        RuleFor(c => c.InstructorDto.UserId).NotEmpty();
        RuleFor(c => c.InstructorDto.FirstName).NotEmpty();
        RuleFor(c => c.InstructorDto.LastName).NotEmpty();
        RuleFor(c => c.InstructorDto.ImageUrl).NotEmpty();
        RuleFor(c => c.InstructorDto.Email).NotEmpty();
        RuleFor(c => c.InstructorDto.BirthDate).NotEmpty();
        RuleFor(c => c.InstructorDto.PhoneNumber).NotEmpty();
        RuleFor(c => c.InstructorDto.About).NotEmpty();
        RuleFor(c => c.InstructorDto.Title).NotEmpty();
       
    }
}