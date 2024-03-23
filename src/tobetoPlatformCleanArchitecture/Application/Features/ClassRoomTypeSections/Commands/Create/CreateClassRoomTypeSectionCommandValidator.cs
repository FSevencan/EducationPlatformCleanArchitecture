using FluentValidation;

namespace Application.Features.ClassRoomTypeSections.Commands.Create;

public class CreateClassRoomTypeSectionCommandValidator : AbstractValidator<CreateClassRoomTypeSectionCommand>
{
    public CreateClassRoomTypeSectionCommandValidator()
    {
        RuleFor(c => c.ClassRoomTypeId).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
        
    }
}