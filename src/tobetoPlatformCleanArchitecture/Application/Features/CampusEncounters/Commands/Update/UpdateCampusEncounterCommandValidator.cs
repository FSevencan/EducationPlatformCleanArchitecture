using FluentValidation;

namespace Application.Features.CampusEncounters.Commands.Update;

public class UpdateCampusEncounterCommandValidator : AbstractValidator<UpdateCampusEncounterCommand>
{
    public UpdateCampusEncounterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.StartDateTime).NotEmpty();
        RuleFor(c => c.Location).NotEmpty();
    }
}