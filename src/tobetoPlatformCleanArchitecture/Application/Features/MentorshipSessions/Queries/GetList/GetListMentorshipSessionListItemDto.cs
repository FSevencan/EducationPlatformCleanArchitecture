using Core.Application.Dtos;

namespace Application.Features.MentorshipSessions.Queries.GetList;

public class GetListMentorshipSessionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Schedule { get; set; }
    public string MeetingId { get; set; }
}