using FluentValidation;

namespace Application.Features.Subscriptions.Commands.Create;

public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
    public CreateSubscriptionCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ClassRoomTypeId).NotEmpty();
    }
}