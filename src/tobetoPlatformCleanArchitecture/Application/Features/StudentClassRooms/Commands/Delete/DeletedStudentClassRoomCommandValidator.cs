using FluentValidation;

namespace Application.Features.StudentClassRooms.Commands.Delete;

public class DeleteStudentClassRoomCommandValidator : AbstractValidator<DeleteStudentClassRoomCommand>
{
    public DeleteStudentClassRoomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}