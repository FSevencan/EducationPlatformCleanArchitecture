using FluentValidation;

namespace Application.Features.Choices.Commands.Update;

public class UpdateChoiceCommandValidator : AbstractValidator<UpdateChoiceCommand>
{
    public UpdateChoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.IsCorrect).NotEmpty();
        
    }
}