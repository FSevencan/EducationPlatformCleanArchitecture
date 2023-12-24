using FluentValidation;

namespace Application.Features.ClassRooms.Commands.Create;

public class CreateClassRoomCommandValidator : AbstractValidator<CreateClassRoomCommand>
{
    public CreateClassRoomCommandValidator()
    {
        RuleFor(c => c.Branch).NotEmpty();
        RuleFor(c => c.ClassRoomTypeId).NotEmpty();
    }
}