using FluentValidation;

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(c => c.UpdateStudentDto.Id).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.FirstName).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.LastName).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.ImageUrl).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.Email).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.BirthDate).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.PhoneNumber).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.Biography).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.GithubUrl).NotEmpty();
        RuleFor(c => c.UpdateStudentDto.LinkedinUrl).NotEmpty();

       
    }
}