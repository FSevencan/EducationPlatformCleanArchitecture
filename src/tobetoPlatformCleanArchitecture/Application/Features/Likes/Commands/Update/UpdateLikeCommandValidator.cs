using FluentValidation;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommandValidator : AbstractValidator<UpdateLikeCommand>
{
    public UpdateLikeCommandValidator()
    {     
        RuleFor(c => c.SectionId).NotEmpty();      
    }
}