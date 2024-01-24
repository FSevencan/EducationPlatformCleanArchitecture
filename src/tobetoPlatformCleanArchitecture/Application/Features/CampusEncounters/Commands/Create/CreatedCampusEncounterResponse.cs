using Core.Application.Responses;

namespace Application.Features.CampusEncounters.Commands.Create;

public class CreatedCampusEncounterResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public string Location { get; set; }
}