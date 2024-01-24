using Core.Application.Responses;

namespace Application.Features.MentorshipSessions.Queries.GetById;

public class GetByIdMentorshipSessionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Schedule { get; set; }
    public string MeetingId { get; set; }
}