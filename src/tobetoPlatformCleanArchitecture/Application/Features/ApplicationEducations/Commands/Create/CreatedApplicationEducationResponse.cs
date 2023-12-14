using Core.Application.Responses;

namespace Application.Features.ApplicationEducations.Commands.Create;

public class CreatedApplicationEducationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}