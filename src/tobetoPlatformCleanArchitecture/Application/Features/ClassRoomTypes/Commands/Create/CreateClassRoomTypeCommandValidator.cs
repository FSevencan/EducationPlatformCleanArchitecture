using FluentValidation;

namespace Application.Features.ClassRoomTypes.Commands.Create;

public class CreateClassRoomTypeCommandValidator : AbstractValidator<CreateClassRoomTypeCommand>
{
    public CreateClassRoomTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}