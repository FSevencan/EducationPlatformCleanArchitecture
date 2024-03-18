using FluentValidation;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommandValidator : AbstractValidator<UpdateLikeCommand>
{
    public UpdateLikeCommandValidator()
    {
        //RuleFor(c => c.Id).NotEmpty();
        //RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
        //RuleFor(c => c.IsActive).NotEmpty();
       // RuleFor(c => c.Student).NotEmpty();
       // RuleFor(c => c.Section).NotEmpty();
    }
}