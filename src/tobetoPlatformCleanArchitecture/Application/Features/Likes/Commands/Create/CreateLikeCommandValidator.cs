using FluentValidation;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommandValidator : AbstractValidator<CreateLikeCommand>
{
    public CreateLikeCommandValidator()
    {
       // RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
       // RuleFor(c => c.IsActive).NotEmpty();
        //RuleFor(c => c.Student).NotEmpty();
        //RuleFor(c => c.Section).NotEmpty();
    }
}