using FluentValidation;

namespace Application.Features.ClassRoomTypeSections.Commands.Delete;

public class DeleteClassRoomTypeSectionCommandValidator : AbstractValidator<DeleteClassRoomTypeSectionCommand>
{
    public DeleteClassRoomTypeSectionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}