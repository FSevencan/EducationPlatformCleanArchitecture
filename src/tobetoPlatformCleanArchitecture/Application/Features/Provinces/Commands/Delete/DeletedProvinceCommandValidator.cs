using FluentValidation;

namespace Application.Features.Provinces.Commands.Delete;

public class DeleteProvinceCommandValidator : AbstractValidator<DeleteProvinceCommand>
{
    public DeleteProvinceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}