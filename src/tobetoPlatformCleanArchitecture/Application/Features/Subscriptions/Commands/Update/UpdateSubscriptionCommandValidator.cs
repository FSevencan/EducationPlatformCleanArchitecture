using FluentValidation;

namespace Application.Features.Subscriptions.Commands.Update;

public class UpdateSubscriptionCommandValidator : AbstractValidator<UpdateSubscriptionCommand>
{
    public UpdateSubscriptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ClassRoomTypeId).NotEmpty();
    }
}