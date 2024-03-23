using Core.Application.Responses;

namespace Application.Features.MentorshipSessions.Commands.Delete;

public class DeletedMentorshipSessionResponse : IResponse
{
    public Guid Id { get; set; }
}