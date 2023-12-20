using FluentValidation;

namespace Application.Features.ClassRooms.Commands.Create;

public class CreateClassRoomCommandValidator : AbstractValidator<CreateClassRoomCommand>
{
    public CreateClassRoomCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}