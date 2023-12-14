using Core.Application.Responses;

namespace Application.Features.Languages.Queries.GetById;

public class GetByIdLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}