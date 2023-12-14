using Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Create;

public class CreatedAnnouncementResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}