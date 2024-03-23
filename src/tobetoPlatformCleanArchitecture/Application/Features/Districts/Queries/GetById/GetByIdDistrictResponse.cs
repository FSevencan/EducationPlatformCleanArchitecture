using Core.Application.Responses;

namespace Application.Features.Districts.Queries.GetById;

public class GetByIdDistrictResponse : IResponse
{
    public int Id { get; set; }
    public int ProvinceId { get; set; }
    public string Name { get; set; }
   
}