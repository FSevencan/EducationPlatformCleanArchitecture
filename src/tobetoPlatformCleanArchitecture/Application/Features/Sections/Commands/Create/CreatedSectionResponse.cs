using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Sections.Commands.Create;

public class CreatedSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public SectionAbout SectionAbout { get; set; }
    public Category? Category { get; set; }
}