using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Districts.Commands.Create;

public class CreatedDistrictResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProvinceId { get; set; }
    public string Name { get; set; }
    public Province Province { get; set; }
}