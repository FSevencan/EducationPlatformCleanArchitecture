using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Sections.Commands.Update;

public class UpdatedSectionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
   
}