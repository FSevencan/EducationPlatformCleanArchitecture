using FluentValidation;

namespace Application.Features.ClassRooms.Commands.Delete;

public class DeleteClassRoomCommandValidator : AbstractValidator<DeleteClassRoomCommand>
{
    public DeleteClassRoomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}