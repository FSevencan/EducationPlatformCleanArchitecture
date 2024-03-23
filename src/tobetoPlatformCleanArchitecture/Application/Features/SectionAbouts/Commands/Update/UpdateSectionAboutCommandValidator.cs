using FluentValidation;

namespace Application.Features.SectionAbouts.Commands.Update;

public class UpdateSectionAboutCommandValidator : AbstractValidator<UpdateSectionAboutCommand>
{
    public UpdateSectionAboutCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProducerCompanyId).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
        RuleFor(c => c.LanguageId).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.EstimatedDuration).NotEmpty();
      
    }
}