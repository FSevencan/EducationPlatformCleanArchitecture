
using Application.Features.Sections.Queries.GetList;
using Core.Application.Dtos;


namespace Application.Features.Categories.Queries.GetListCategorySections;
public class GetListCategorySectionsListItemDto : IDto
{  
    public ICollection<GetListSectionListItemDto> Sections   { get; set; }
}
