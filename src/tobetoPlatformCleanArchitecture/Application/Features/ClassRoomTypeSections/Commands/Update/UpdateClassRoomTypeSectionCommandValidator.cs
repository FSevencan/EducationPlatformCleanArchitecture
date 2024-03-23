using FluentValidation;

namespace Application.Features.ClassRoomTypeSections.Commands.Update;

public class UpdateClassRoomTypeSectionCommandValidator : AbstractValidator<UpdateClassRoomTypeSectionCommand>
{
    public UpdateClassRoomTypeSectionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ClassRoomTypeId).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
       
    }
}