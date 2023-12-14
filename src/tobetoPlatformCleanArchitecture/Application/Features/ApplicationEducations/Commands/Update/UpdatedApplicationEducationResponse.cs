using Core.Application.Responses;

namespace Application.Features.ApplicationEducations.Commands.Update;

public class UpdatedApplicationEducationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}