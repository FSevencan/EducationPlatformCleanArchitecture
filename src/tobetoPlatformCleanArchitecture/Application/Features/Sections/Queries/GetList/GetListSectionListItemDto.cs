using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.Sections.Queries.GetList;

public class GetListSectionListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public SectionAbout SectionAbout { get; set; }
    public Category? Category { get; set; }
}