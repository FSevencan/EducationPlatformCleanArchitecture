using Core.Application.Dtos;

namespace Application.Features.ApplicationEducations.Queries.GetList;

public class GetListApplicationEducationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}