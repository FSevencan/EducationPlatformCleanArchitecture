using FluentValidation;

namespace Application.Features.MentorshipSessions.Commands.Delete;

public class DeleteMentorshipSessionCommandValidator : AbstractValidator<DeleteMentorshipSessionCommand>
{
    public DeleteMentorshipSessionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}