using Core.Application.Responses;

namespace Application.Features.CampusEncounters.Queries.GetById;

public class GetByIdCampusEncounterResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public string Location { get; set; }
}