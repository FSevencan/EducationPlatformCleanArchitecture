using FluentValidation;

namespace Application.Features.Questions.Commands.Create;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
     
    }
}