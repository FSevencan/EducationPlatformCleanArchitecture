using FluentValidation;

namespace Application.Features.ClassRoomTypes.Commands.Delete;

public class DeleteClassRoomTypeCommandValidator : AbstractValidator<DeleteClassRoomTypeCommand>
{
    public DeleteClassRoomTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}