using Core.Application.Dtos;

namespace Application.Features.Provinces.Queries.GetList;

public class GetListProvinceListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}