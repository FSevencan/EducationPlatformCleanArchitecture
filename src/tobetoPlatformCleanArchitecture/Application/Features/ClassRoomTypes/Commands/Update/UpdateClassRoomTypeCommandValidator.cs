using FluentValidation;

namespace Application.Features.ClassRoomTypes.Commands.Update;

public class UpdateClassRoomTypeCommandValidator : AbstractValidator<UpdateClassRoomTypeCommand>
{
    public UpdateClassRoomTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}