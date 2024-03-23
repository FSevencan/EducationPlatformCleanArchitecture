using Core.Application.Dtos;

namespace Application.Features.Districts.Queries.GetList;

public class GetListDistrictListItemDto : IDto
{
    public int Id { get; set; }
    public int ProvinceId { get; set; }
    public string Name { get; set; }
    
}