using FluentValidation;

namespace Application.Features.Lessons.Commands.Update;

public class UpdateLessonCommandValidator : AbstractValidator<UpdateLessonCommand>
{
    public UpdateLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProducerCompanyId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Time).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}