using FluentValidation;

namespace Application.Features.MentorshipSessions.Commands.Update;

public class UpdateMentorshipSessionCommandValidator : AbstractValidator<UpdateMentorshipSessionCommand>
{
    public UpdateMentorshipSessionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.Schedule).NotEmpty();
        RuleFor(c => c.MeetingId).NotEmpty();
    }
}