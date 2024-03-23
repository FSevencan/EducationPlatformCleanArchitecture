using FluentValidation;

namespace Application.Features.CampusEncounters.Commands.Delete;

public class DeleteCampusEncounterCommandValidator : AbstractValidator<DeleteCampusEncounterCommand>
{
    public DeleteCampusEncounterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}