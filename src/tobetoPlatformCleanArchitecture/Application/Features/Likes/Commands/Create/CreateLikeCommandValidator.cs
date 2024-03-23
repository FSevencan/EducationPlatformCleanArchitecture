using FluentValidation;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommandValidator : AbstractValidator<CreateLikeCommand>
{
    public CreateLikeCommandValidator()
    {
        RuleFor(c => c.SectionId).NotEmpty();
    }
}