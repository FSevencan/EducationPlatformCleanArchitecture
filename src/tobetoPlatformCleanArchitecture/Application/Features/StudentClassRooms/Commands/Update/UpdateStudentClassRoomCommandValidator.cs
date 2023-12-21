using FluentValidation;

namespace Application.Features.StudentClassRooms.Commands.Update;

public class UpdateStudentClassRoomCommandValidator : AbstractValidator<UpdateStudentClassRoomCommand>
{
    public UpdateStudentClassRoomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ClassRoomId).NotEmpty();
      
    }
}