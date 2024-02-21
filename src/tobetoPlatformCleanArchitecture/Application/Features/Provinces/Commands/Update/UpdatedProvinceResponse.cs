using Core.Application.Responses;

namespace Application.Features.Provinces.Commands.Update;

public class UpdatedProvinceResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}