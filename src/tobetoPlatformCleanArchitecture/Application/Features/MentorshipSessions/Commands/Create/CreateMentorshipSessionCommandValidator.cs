using FluentValidation;

namespace Application.Features.MentorshipSessions.Commands.Create;

public class CreateMentorshipSessionCommandValidator : AbstractValidator<CreateMentorshipSessionCommand>
{
    public CreateMentorshipSessionCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.Schedule).NotEmpty();
        RuleFor(c => c.MeetingId).NotEmpty();
    }
}