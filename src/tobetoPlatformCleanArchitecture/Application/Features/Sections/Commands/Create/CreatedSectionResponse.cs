using Core.Application.Responses;

namespace Application.Features.Sections.Commands.Create;

public class CreatedSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}