using FluentValidation;

namespace Application.Features.Students.Commands.Delete;

public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}