using FluentValidation;

namespace Application.Features.ClassRooms.Commands.Update;

public class UpdateClassRoomCommandValidator : AbstractValidator<UpdateClassRoomCommand>
{
    public UpdateClassRoomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Branch).NotEmpty();
        RuleFor(c => c.ClassRoomTypeId).NotEmpty();
    }
}