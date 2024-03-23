using Core.Application.Responses;

namespace Application.Features.Provinces.Queries.GetById;

public class GetByIdProvinceResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}