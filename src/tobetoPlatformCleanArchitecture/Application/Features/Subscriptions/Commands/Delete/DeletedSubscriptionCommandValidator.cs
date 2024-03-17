using FluentValidation;

namespace Application.Features.Subscriptions.Commands.Delete;

public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
{
    public DeleteSubscriptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}