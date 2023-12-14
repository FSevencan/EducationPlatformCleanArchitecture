using Core.Application.Dtos;

namespace Application.Features.Announcements.Queries.GetList;

public class GetListAnnouncementListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}