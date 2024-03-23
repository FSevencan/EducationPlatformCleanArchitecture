using Core.Application.Dtos;

namespace Application.Features.CampusEncounters.Queries.GetList;

public class GetListCampusEncounterListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDateTime { get; set; }
    public string Location { get; set; }
}