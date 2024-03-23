using Core.Application.Responses;

namespace Application.Features.CampusEncounters.Commands.Delete;

public class DeletedCampusEncounterResponse : IResponse
{
    public Guid Id { get; set; }
}