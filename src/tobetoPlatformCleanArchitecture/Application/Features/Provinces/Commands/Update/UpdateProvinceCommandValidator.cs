using FluentValidation;

namespace Application.Features.Provinces.Commands.Update;

public class UpdateProvinceCommandValidator : AbstractValidator<UpdateProvinceCommand>
{
    public UpdateProvinceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}