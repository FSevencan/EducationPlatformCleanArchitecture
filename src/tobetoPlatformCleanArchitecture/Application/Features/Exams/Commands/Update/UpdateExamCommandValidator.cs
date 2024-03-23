using FluentValidation;

namespace Application.Features.Exams.Commands.Update;

public class UpdateExamCommandValidator : AbstractValidator<UpdateExamCommand>
{
    public UpdateExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ClassRoomTypeId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.QuestionCount).NotEmpty();
        RuleFor(c => c.QuestionType).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
     
    }
}