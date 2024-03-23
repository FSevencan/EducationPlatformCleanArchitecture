using FluentValidation;

namespace Application.Features.StudentClassRooms.Commands.Create;

public class CreateStudentClassRoomCommandValidator : AbstractValidator<CreateStudentClassRoomCommand>
{
    public CreateStudentClassRoomCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ClassRoomId).NotEmpty();
      
    }
}