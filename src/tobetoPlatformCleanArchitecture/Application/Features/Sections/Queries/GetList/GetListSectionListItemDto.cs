using Core.Application.Dtos;

namespace Application.Features.Sections.Queries.GetList;

public class GetListSectionListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}

