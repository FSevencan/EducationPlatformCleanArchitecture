using Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Delete;

public class DeletedAnnouncementResponse : IResponse
{
    public Guid Id { get; set; }
}