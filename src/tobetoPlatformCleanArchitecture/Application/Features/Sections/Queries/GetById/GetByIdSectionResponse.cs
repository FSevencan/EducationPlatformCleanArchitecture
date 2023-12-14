using Core.Application.Responses;

namespace Application.Features.Sections.Queries.GetById;

public class GetByIdSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SectionAboutId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}