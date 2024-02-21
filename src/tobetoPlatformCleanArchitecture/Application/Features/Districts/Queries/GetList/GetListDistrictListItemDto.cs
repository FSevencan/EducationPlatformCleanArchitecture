using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.Districts.Queries.GetList;

public class GetListDistrictListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ProvinceId { get; set; }
    public string Name { get; set; }
    public Province Province { get; set; }
}