using Core.Application.Responses;

namespace Application.Features.MentorshipSessions.Commands.Update;

public class UpdatedMentorshipSessionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Schedule { get; set; }
    public string MeetingId { get; set; }
}