using Core.Application.Responses;

namespace Application.Features.ApplicationEducations.Queries.GetById;

public class GetByIdApplicationEducationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}