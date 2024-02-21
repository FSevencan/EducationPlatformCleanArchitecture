using FluentValidation;

namespace Application.Features.Provinces.Commands.Create;

public class CreateProvinceCommandValidator : AbstractValidator<CreateProvinceCommand>
{
    public CreateProvinceCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}