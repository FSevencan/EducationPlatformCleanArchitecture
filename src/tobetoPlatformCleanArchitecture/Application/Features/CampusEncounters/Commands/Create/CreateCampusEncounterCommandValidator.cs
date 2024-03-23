using FluentValidation;

namespace Application.Features.CampusEncounters.Commands.Create;

public class CreateCampusEncounterCommandValidator : AbstractValidator<CreateCampusEncounterCommand>
{
    public CreateCampusEncounterCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.StartDateTime).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
    }
}