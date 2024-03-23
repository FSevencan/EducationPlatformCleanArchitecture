using FluentValidation;

namespace Application.Features.Districts.Commands.Update;

public class UpdateDistrictCommandValidator : AbstractValidator<UpdateDistrictCommand>
{
    public UpdateDistrictCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProvinceId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Province).NotEmpty();
    }
}