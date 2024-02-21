using Core.Application.Responses;

namespace Application.Features.Provinces.Commands.Create;

public class CreatedProvinceResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}