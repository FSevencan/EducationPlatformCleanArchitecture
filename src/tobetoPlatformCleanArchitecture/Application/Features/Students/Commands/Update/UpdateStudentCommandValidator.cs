using FluentValidation;

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(c => c.StudentDto.Id).NotEmpty();
        RuleFor(c => c.StudentDto.UserId).NotEmpty();
        RuleFor(c => c.StudentDto.FirstName).NotEmpty();
        RuleFor(c => c.StudentDto.LastName).NotEmpty();
        RuleFor(c => c.StudentDto.ImageUrl).NotEmpty();
        RuleFor(c => c.StudentDto.Email).NotEmpty();
        RuleFor(c => c.StudentDto.BirthDate).NotEmpty();
        RuleFor(c => c.StudentDto.PhoneNumber).NotEmpty();
        RuleFor(c => c.StudentDto.About).NotEmpty();
        RuleFor(c => c.StudentDto.GithubUrl).NotEmpty();
        RuleFor(c => c.StudentDto.LinkedinUrl).NotEmpty();

       
    }
}